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
          cd Domain-driven-design/tests
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
      post {
        success {
          echo 'Build successfull! You should deploy! :)'
        }
        failure {
          emailext body: 'docker-compose up failed',
          recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
          subject: 'Docker-Compose up (Run application failed)'
        }
      }
    }
    // stage('9.Publish Docker Images') {
    //   when {
    //     branch 'master'
    //   }
    //   steps {
    //     script {
    //       docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {
    //         // Microservice images
    //         def identityImage = docker.image('kristianlyubenov/petfoodshop-identity-ms')
    //         identityImage.push("0.0.${env.BUILD_ID}")
    //         identityImage.push('latest')

    //         def cartImage = docker.image('kristianlyubenov/petfoodshop-cart-ms')
    //         cartImage.push("0.0.${env.BUILD_ID}")
    //         cartImage.push('latest')

    //         def foodsImage = docker.image('kristianlyubenov/petfoodshop-foods-ms')
    //         foodsImage.push("0.0.${env.BUILD_ID}")
    //         foodsImage.push('latest')

    //         def notificationsImage = docker.image('kristianlyubenov/petfoodshop-notifications-ms')
    //         notificationsImage.push("0.0.${env.BUILD_ID}")
    //         notificationsImage.push('latest')

    //         def statisticsImage = docker.image('kristianlyubenov/petfoodshop-statistics-ms')
    //         statisticsImage.push("0.0.${env.BUILD_ID}")
    //         statisticsImage.push('latest')

    //         // Gateway image
    //         def foodsgatewayImage = docker.image('kristianlyubenov/petfoodshop-foodsgateway-api')
    //         foodsgatewayImage.push("0.0.${env.BUILD_ID}")
    //         foodsgatewayImage.push('latest')

    //         // Admin and UI clients
    //         def adminImage = docker.image('kristianlyubenov/petfoodshop-admin-client')
    //         adminImage.push("0.0.${env.BUILD_ID}")
    //         adminImage.push('latest')

    //         def angularClientImage = docker.image('kristianlyubenov/petfoodshop-angular-client')
    //         angularClientImage.push("0.0.${env.BUILD_ID}")
    //         angularClientImage.push('latest')

    //         def watchdogImage = docker.image('kristianlyubenov/petfoodshop-watchdog')
    //         watchdogImage.push("0.0.${env.BUILD_ID}")
    //         watchdogImage.push('latest')
    //       }
    //     }
    //   }
    //   post {
    //     success {
    //       emailext body: 'Job executed successful :)',
    //       recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
    //       subject: 'Successfully pushed docker images'
    //     }
    //     failure {
    //       emailext body: 'docker image push failed',
    //       recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
    //       subject: 'Pushing docker images failed'
    //     }
    //   }
    // }
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
              withKubeConfig([credentialsId: 'ProductionServer', serverUrl: 'https://']) {
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/.environment/development.yml')
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
                powershell(script: 'kubectl apply -f ./Domain-driven-design/.k8s/.environment/development.yml')
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
        steps {
          powershell(script: """
          cd Domain-driven-design/tests/PetFoodShop-Automations
          launchTests-${CURRENT_ENV}.cmd
        """)
        }
      }
    }
  }
}