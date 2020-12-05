pipeline {
  environment {
    CURRENT_ENV = 'development'
  }

  agent any
  stages {
    stage('1.Verify Branch') {
      steps {
        echo 'BRANCH --> ' + env.BRANCH_NAME
      }
    }
    stage('2.Pull Changes') {
      steps {
        powershell(script: "git pull")
      }
    }
    stage('3.Run Unit&Integration Tests') {
      steps {
        powershell(script: '''
          cd Domain-driven-design/server
          dotnet test
          cd ..
        ''')
      }
    }
    stage('4.Deploy to PROD?') {
      steps {
        script {
          def userInput = input(
          message: 'User input required - Deploy to PRODUCTION?', parameters: [[$class: 'ChoiceParameterDefinition', choices: ['yes', 'no'].join('\n'), name: 'input', description: 'Menu - select box option']])
          if ("${userInput}" == "yes") {
            $CURRENT_ENV = 'production'
          }
          echo "Environment -->  ${CURRENT_ENV}"
        }
      }
    }
    stage('5.Run Docker Build') {
      steps {
        powershell(script: """
          cd Domain-driven-design
          docker-compose build
          cd client
          docker build -t kristianlyubenov/petfoodshop-user-client-${CURRENT_ENV}:0.0.${env.BUILD_ID} --build-arg configuration=\"${CURRENT_ENV}\" .
          docker push kristianlyubenov/petfoodshop-user-client-${CURRENT_ENV}:0.0.${env.BUILD_ID}
        """)
      }
      post {
        success {
          echo 'Docker-Build succeed!'
        }
        failure {
          echo '------------------------->[ERROR] Docker-Build FAILED!'
        }
      }
    }
    stage('6.Run Application') {
      steps {
        powershell(script: '''
          cd Domain-driven-design
          docker-compose up -d
          cd ..
        ''')
      }
      post {
        success {
          echo 'Docker-Up succeed!'
        }
        failure {
          echo '------------------------->[ERROR] Docker-Up FAILED!'
        }
      }
    }
    stage('7.Run e2e tests on docker images') {
      steps {
        powershell(script: '''
          cd Domain-driven-design
          cd tests
          ContainerTests.ps1
        ''')
      }
    }
    stage('8.Stop Application') {
      steps {
        powershell(script: '''
          cd Domain-driven-design
          docker-compose down
        ''')
      }
    }
    stage('9.Publish docker images') {
      when {
        branch 'master'
      }
      steps {
        script {
          docker.withregistry('https://index.docker.io/v1/', 'DockerHub') {
            // microservice images
            def identityimage = docker.image('kristianlyubenov/petfoodshop-identity-ms')
            identityimage.push("0.0.${env.BUILD_ID}")
            identityimage.push('latest')
	
            def cartimage = docker.image('kristianlyubenov/petfoodshop-cart-ms')
            cartimage.push("0.0.${env.BUILD_ID}")
            cartimage.push('latest')
	
            def foodsimage = docker.image('kristianlyubenov/petfoodshop-foods-ms')
            foodsimage.push("0.0.${env.BUILD_ID}")
            foodsimage.push('latest')
	
            def notificationsimage = docker.image('kristianlyubenov/petfoodshop-notifications-ms')
            notificationsimage.push("0.0.${env.BUILD_ID}")
            notificationsimage.push('latest')
	
            def statisticsimage = docker.image('kristianlyubenov/petfoodshop-statistics-ms')
            statisticsimage.push("0.0.${env.BUILD_ID}")
            statisticsimage.push('latest')
	
            // gateway image
            def foodsgatewayimage = docker.image('kristianlyubenov/petfoodshop-foodsgateway-api')
            foodsgatewayimage.push("0.0.${env.BUILD_ID}")
            foodsgatewayimage.push('latest')
	
            // admin and ui clients
            def adminimage = docker.image('kristianlyubenov/petfoodshop-admin-client')
            adminimage.push("0.0.${env.BUILD_ID}")
            adminimage.push('latest')
	
            def angularclientimage = docker.image('kristianlyubenov/petfoodshop-angular-client')
            angularclientimage.push("0.0.${env.BUILD_ID}")
            angularclientimage.push('latest')
	
            def watchdogimage = docker.image('kristianlyubenov/petfoodshop-watchdog')
            watchdogimage.push("0.0.${env.BUILD_ID}")
            watchdogimage.push('latest')
          }
        }
      }
      post {
        success {
          emailext body: 'job executed successful :)',
          recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
          subject: 'successfully pushed docker images'
        }
        failure {
          emailext body: 'docker image push failed',
          recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
          subject: 'pushing docker images failed'
        }
      }
    }
    stage('10.Deploy to k8s') {
      steps {
        // DUE to gcloud limitations we can apply only 4 external IPs
        script {
          if ("${CURRENT_ENV}" == "production") {
            // Replace image tag for webservices to point to concrete version
            stage('Deploy to PROD') {
              def filePath = "./Domain-driven-design/.k8s/web-services/";
              contentReplace(
              configs: [
              fileContentReplaceConfig(
              configs: [
              fileContentReplaceItemConfig(search: 'image: kristianlyubenov/petfoodshop-cart-ms:latest', replace: "image: kristianlyubenov/petfoodshop-cart-ms:0.0.${env.BUILD_ID}", matchCount: 1)], fileEncoding: 'UTF-8', filePath: "${filePath}cart-service.yml")])
              contentReplace(
              configs: [
              fileContentReplaceConfig(
              configs: [
              fileContentReplaceItemConfig(search: 'image: kristianlyubenov/petfoodshop-foods-ms:latest', replace: "image: kristianlyubenov/petfoodshop-foods-ms:0.0.${env.BUILD_ID}", matchCount: 1)], fileEncoding: 'UTF-8', filePath: "${filePath}foods-service.yml")])
              contentReplace(
              configs: [
              fileContentReplaceConfig(
              configs: [
              fileContentReplaceItemConfig(search: 'image: kristianlyubenov/petfoodshop-identity-ms:latest', replace: "image: kristianlyubenov/petfoodshop-identity-ms:0.0.${env.BUILD_ID}", matchCount: 1)], fileEncoding: 'UTF-8', filePath: "${filePath}identity-service.yml")])
              // kubectl apply them all
              withKubeConfig([credentialsId: 'ProductionServer', serverUrl: 'https://34.68.98.149']) {
                powershell(script: "kubectl apply -f ./Domain-driven-design/.k8s/.environment/${CURRENT_ENV}.yml")
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/databases')
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/event-bus')
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/web-services/identity-service.yml')
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/web-services/foods-service.yml')
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/web-services/cart-service.yml')
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/clients/user-client.yml')
                powershell(script: "kubectl set image deployments/user-client user-client=kristianlyubenov/petfoodshop-user-client-${CURRENT_ENV}:0.0.${env.BUILD_ID}")
              }
            }
          } else {
            stage('Deploy to DEV') {
              withKubeConfig([credentialsId: 'DevelopmentServer', serverUrl: 'https://34.71.199.17']) {
                powershell(script: "kubectl apply -f ./Domain-driven-design/.k8s/.environment/${CURRENT_ENV}.yml")
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/databases')
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/event-bus')

                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/web-services/identity-service.yml')
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/web-services/foods-service.yml')
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/web-services/cart-service.yml')

                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/clients/user-client.yml')
                powershell(script: "kubectl set image deployments/user-client user-client=kristianlyubenov/petfoodshop-user-client-${CURRENT_ENV}:latest")
              }
            }
          }
        }
      }
    }
    stage('11.Run automation tests on cluster') {
      steps {        
        powershell(script: """
          cd Domain-driven-design/tests/PetFoodShop-Automations
          launchTests-${CURRENT_ENV}.cmd
        """)
        }
    }
  }
}