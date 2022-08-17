pipeline {
    environment {
    imagename = "mylocaldocker3103/suggestionApi"
    dockerImage = ''
  }

    agent any

    stages {
        stage('Cloning Git') {
            steps {
                git 'https://github.com/VadymIan/SuggestionApi.git'
            }
        }
        stage('Building') {
            steps {
		 sh 'dir'
                 sh 'dotnet build SuggestionApplication.sln --configuration Release'
            }
        }
        stage('Running Tests') {
            steps {
                sh 'dotnet test --logger "trx;LogFileName=TestResult.trx" SuggestionApplication/SuggestionApplication.Tests.csproj'
            }
            
            post {
                always {
                    ws('/var/lib/jenkins/workspace/SuggestionAPI/SuggestionApplication.Tests/TestResults')
                    {
                        mstest()
                    }                    
                }
            }
        }
	stage('Building Image') {
		steps {
			script {
				dockerImage = docker.build(imagename)
			}
		}
	}
	stage('Pushing Image') {
		steps {
			script {
				docker.withRegistry('https://registry.hub.docker.com', 'myapp') {
					dockerImage.push('latest')
				}
			}
		}
	}
    }
}
