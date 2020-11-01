pipeline {
  agent any
  stages {
    //stage('Verify Branch') {
    //  steps {
    //    echo "$GIT_BRANCH"
    //  }
    //}
    stage('Run Unit Tests') {
      steps {
        powershell(script: """ 
          cd Domain-driven-design/server
          dotnet test
          cd ..
        """)
      }
    }
    stage('Docker Build') {
      steps {
        powershell(script: 'docker-compose build')     
        powershell(script: 'docker images -a')
      }
    }
	stage('Run Test Application') {
      steps {
        powershell(script: 'docker-compose up -d')    
      }
    }
    stage('Run Integration Tests') {
      steps {
        powershell(script: './Tests/ContainerTests.ps1') 
      }
    }
    //stage('Stop Test Application') {
    //  steps {
    //    powershell(script: 'docker-compose down') 
    //    // powershell(script: 'docker volumes prune -f')   		
    //  }
    //  post {
	//    success {
	//      echo "Build successfull! You should deploy! :)"
	//    }
	//    failure {
	//      echo "Build failed! You should receive an e-mail! :("
	//    }
    //  }
    //}
    //stage('Push Images') {
    //  when { branch 'master' }
    //  steps {
    //    script {
    //      docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {
    //        def image = docker.image("kristianlyubenov/petfoodshop-identity-ms")
    //        image.push("0.0.${env.BUILD_ID}")
    //        image.push('latest')
    //      }
    //    }
    //  }
    //}
  }
}
