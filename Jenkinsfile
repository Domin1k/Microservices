pipeline {
  agent any
  stages {
    //stage('Verify Branch') {
    //  steps {
    //    echo "$GIT_BRANCH"
    //  }
    //}
    stage('1.Run Unit&Integration Tests') {
      steps {
        powershell(script: """ 
          cd Domain-driven-design/server
          dotnet test
          cd ..
        """)
      }
    }
    stage('2.Run Docker Build') {
      steps {
		powershell(script: """ 
		  cd Domain-driven-design
          docker-compose build
        """)
        powershell(script: 'docker images -a')
      }
    }
	stage('3.Run Application') {
      steps {
		powershell(script: """ 
		  cd Domain-driven-design
          docker-compose up -d
        """)
      }
    }
    stage('4.Run e2e Tests') {
      steps {
		powershell(script: """ 
		  cd Domain-driven-design/tests
		  ContainerTests.ps1
        """)
      }
    }
    stage('5.Stop Application') {
      steps {
		powershell(script: """ 
		  cd Domain-driven-design
		  docker-compose down
        """)
        // powershell(script: 'docker volumes prune -f')   		
      }
      post {
	    success {
	      echo "Build successfull! You should deploy! :)"
	    }
	    failure {
	      echo "Build failed! You should receive an e-mail! :("
	    }
      }
    }
    stage('6.Publish Docker Images') {
      when { branch 'master' }
      steps {
        script {
          docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {
            def image = docker.image("kristianlyubenov/petfoodshop-identity-ms")
            image.push("0.0.${env.BUILD_ID}")
            image.push('latest')
          }
        }
      }
    }
  }
}
