#install and configure minikube
brew install minikube
sudo mv minikube /usr/local/bin
minikube start --vm-driver=virtualbox
minikube addons enable ingress

#install secrets json file
kubectl create secret generic secret-appsettings --from-file=./appsettings.secrets.json

#build user service docker image
docker build -f UserService.Dockerfile -t drmoz/userservice:v1 .
docker push drmoz/userservice:v1

#build migrations docker image
docker build -f UserService-Migration.Dockerfile -t drmoz/userservice-migrations:v1 .
docker push drmoz/userservice-migrations:v1