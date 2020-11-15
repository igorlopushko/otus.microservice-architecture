#install and configure minikube<br />
brew install minikube<br />
sudo mv minikube /usr/local/bin<br />
minikube start --vm-driver=virtualbox<br />
minikube addons enable ingress<br />

#install secrets json file<br />
kubectl create secret generic secret-appsettings --from-file=./appsettings.secrets.json

#build user service docker image<br />
docker build -f UserService.Dockerfile -t drmoz/userservice:v1 .<br />
docker push drmoz/userservice:v1

#build migrations docker image<br />
docker build -f UserService-Migration.Dockerfile -t drmoz/userservice-migrations:v1 .<br />
docker push drmoz/userservice-migrations:v1<br /><br />



#apply skaffold.yaml<br/>

#call to check service health:<br/>
curl -H'Host:arch.homework' -GET -i http://192.168.99.102/otusapp/IgorLopushko/health
