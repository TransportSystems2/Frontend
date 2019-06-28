pipeline {
    agent {
        label 'ios'
    }
    stages {
        stage('Build') {
            steps {
                sh './build.sh'
            }
        }
    }
}