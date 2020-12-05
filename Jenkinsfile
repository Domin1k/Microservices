pipeline {
  environment {
    CURRENT_ENV = 'development'
  }

  agent any
  stages {
    stage('1.Verify Branch') {
      steps {
        powershell(script: "git pull")
        contentReplace(
          configs: [
          fileContentReplaceConfig(
          configs: [
          fileContentReplaceItemConfig(
          search: '(image\:)\s*\w+.\w+.\w*..*', replace: "(image\:)\s*\w+.\w+.\w*..*:0.0.${env.BUILD_ID}", matchCount: 1)], fileEncoding: 'UTF-8', filePath: './Domain-driven-design/.k8s/web-services/cart-service.yml')])
      }
    }
  }
}