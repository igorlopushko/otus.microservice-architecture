# install and configure minikube<br />
brew install minikube<br />
# start minikube
sudo mv minikube /usr/local/bin<br />
minikube start --vm-driver=virtualbox<br />
minikube addons enable ingress<br />
# install secrets json file<br />
kubectl create namespace user-svc
kubectl config set-context --current --namespace=user-svc
kubectl create secret generic user-svc-app-secret --from-file=./config/UserService/appsettings.secret.json
# build user service docker image<br />
cd solution
docker build -f UserService.Dockerfile -t drmoz/userservice:v1 .<br />
docker push drmoz/userservice:v1
# build migrations docker image<br />
docker build -f UserService-Migration.Dockerfile -t drmoz/userservice-migrations:v1 .<br />
docker push drmoz/userservice-migrations:v1<br /><br />

apply skaffold.yaml<br/>

# call to check service health:<br/>
minikube service --url user-svc-app -n user-svc
curl -H'Host:arch.homework' -GET -i http://192.168.99.105/otusapp/IgorLopushko/health