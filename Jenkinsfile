pipeline {
    agent {
        label 'ios'
    }
    stages {
        stage('Clean') {
            steps {
                sh "./build.sh -ScriptArgs '-target=Clean'"
            }
        }
        stage('Restore') {
            steps {
                sh "./build.sh -ScriptArgs '-target=Restore'"
            }
        }
        stage('Build') {
            steps {
                sh "./build.sh -ScriptArgs '-target=Build'"
            }
        }
        stage('Install') {
            steps {
                sh "./build.sh -ScriptArgs '-target=Install'"
            }
        }
        stage('Tests') {
            steps {
                sh "./build.sh -ScriptArgs '-target=Tests'"
            }
        }
    }
}