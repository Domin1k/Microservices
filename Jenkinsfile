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
        powershell(script: '''
          cd Domain-driven-design
          docker-compose build
          cd client
        ''')

        script {
          if ("${CURRENT_ENV}" == 'production') {
            powershell(script: "docker build -t kristianlyubenov/petfoodshop-user-client-production:0.0.${env.BUILD_ID} --build-arg configuration=\"production\" .")
            powershell(script: "docker push kristianlyubenov/petfoodshop-user-client-production:0.0.${env.BUILD_ID}")
          } else {
            powershell(script: "docker build -t kristianlyubenov/petfoodshop-user-client-development:0.0.${env.BUILD_ID} --build-arg configuration=\"${CURRENT_ENV}\" .")
            powershell(script: "docker push kristianlyubenov/petfoodshop-user-client-development:0.0.${env.BUILD_ID}")
          }
        }
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
    stage('7.Run e2e Tests') {
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
    stage('9.Publish Docker Images') {
      when {
        branch 'master'
      }
      steps {
        script {
          docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {
            // Microservice images
            def identityImage = docker.image('kristianlyubenov/petfoodshop-identity-ms')
            identityImage.push("0.0.${env.BUILD_ID}")
            identityImage.push('latest')

            def cartImage = docker.image('kristianlyubenov/petfoodshop-cart-ms')
            cartImage.push("0.0.${env.BUILD_ID}")
            cartImage.push('latest')

            def foodsImage = docker.image('kristianlyubenov/petfoodshop-foods-ms')
            foodsImage.push("0.0.${env.BUILD_ID}")
            foodsImage.push('latest')

            def notificationsImage = docker.image('kristianlyubenov/petfoodshop-notifications-ms')
            notificationsImage.push("0.0.${env.BUILD_ID}")
            notificationsImage.push('latest')

            def statisticsImage = docker.image('kristianlyubenov/petfoodshop-statistics-ms')
            statisticsImage.push("0.0.${env.BUILD_ID}")
            statisticsImage.push('latest')

            // Gateway image
            def foodsgatewayImage = docker.image('kristianlyubenov/petfoodshop-foodsgateway-api')
            foodsgatewayImage.push("0.0.${env.BUILD_ID}")
            foodsgatewayImage.push('latest')

            // Admin and UI clients
            def adminImage = docker.image('kristianlyubenov/petfoodshop-admin-client')
            adminImage.push("0.0.${env.BUILD_ID}")
            adminImage.push('latest')

            def angularClientImage = docker.image('kristianlyubenov/petfoodshop-angular-client')
            angularClientImage.push("0.0.${env.BUILD_ID}")
            angularClientImage.push('latest')

            def watchdogImage = docker.image('kristianlyubenov/petfoodshop-watchdog')
            watchdogImage.push("0.0.${env.BUILD_ID}")
            watchdogImage.push('latest')
          }
        }
      }
      post {
        success {
          emailext body: 'Job executed successful :)',
          recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
          subject: 'Successfully pushed docker images'
        }
        failure {
          emailext body: 'docker image push failed',
          recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
          subject: 'Pushing docker images failed'
        }
      }
    }
  }
}