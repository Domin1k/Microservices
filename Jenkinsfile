pipeline {
  agent any
  stages {
    stage('Verify Branch') {
     steps {
       for(e in env){
        echo e + " is " + ${e}
       }
     }
    }
    // stage('1.Run Unit&Integration Tests') {
    //   steps {
    //     powershell(script: '''
    //       cd Domain-driven-design/server
    //       dotnet test
    //       cd ..
    //     ''')
    //   }
    // }
    // stage('2.Run Docker Build') {
    //   steps {
    //     powershell(script: '''
    //       cd Domain-driven-design
    //       docker-compose build
    //     ''')
    //     powershell(script: 'docker images -a')
    //   }
    // }
    // stage('3.Run Application') {
    //   steps {
    //     powershell(script: '''
    //       cd Domain-driven-design
    //       docker-compose up -d
    //     ''')
    //   }
    // }
    // stage('4.Run e2e Tests') {
    //   steps {
    //     powershell(script: '''
    //       cd Domain-driven-design/tests
    //       ContainerTests.ps1
    //     ''')
    //   }
    // }
    // stage('5.Stop Application') {
    //   steps {
    //     powershell(script: '''
    //       cd Domain-driven-design
    //       docker-compose down
    //     ''')
    //     // powershell(script: '''
    //     //   cd Domain-driven-design
    //     //   docker volumes prune -f
    //     // ''')
    //   }
    //   post {
    //     success {
    //       echo 'Build successfull! You should deploy! :)'
    //     }
    //     failure {
    //       emailext body: 'docker-compose up failed', recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']], subject: 'Docker-Compose up (Run application failed)'
    //     }
    //   }
    // }
    // stage('6.Publish Docker Images') {
    //   when { branch 'master' }
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

    //         def watchdogImage = docker.image('kristianlyubenov/petfoodshop-watchdog')
    //         watchdogImage.push("0.0.${env.BUILD_ID}")
    //         watchdogImage.push('latest')

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
    //       }
    //     }
    //   }
    //   post {
    //     success {
    //       emailext body: 'Build successfull! You should deploy! :)', recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']], subject: 'Successfully pushed docker images'
    //     }
    //     failure {
    //       emailext body: 'docker image push failed', recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']], subject: 'Pushing docker images failed'
    //     }
    //   }
    // }
  }
}
