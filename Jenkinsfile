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
  }