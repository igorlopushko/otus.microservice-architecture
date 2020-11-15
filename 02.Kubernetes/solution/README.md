brew install minikube
sudo mv minikube /usr/local/bin
minikube start --vm-driver=virtualbox
minikube addons enable ingress

kubectl create secret generic secret-appsettings --from-file=./appsettings.secrets.json

docker build -f UserService.Dockerfile -t drmoz/userservice:v1 .
docker push drmoz/userservice:v1

docker build -f UserService-Migration.Dockerfile -t drmoz/userservice-migrations:v1 .
docker push drmoz/userservice-migrations:v1