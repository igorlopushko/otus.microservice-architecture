# install and configure minikube<br />
brew install minikube<br />
# start minikube
sudo mv minikube /usr/local/bin<br />
minikube start --vm-driver=virtualbox<br />
minikube addons enable ingress<br />
# build user service docker image<br />
cd src
docker build -f UserService.Dockerfile -t drmoz/userservice:v1 .<br />
docker push drmoz/userservice:v1
# build migrations docker image<br />
docker build -f UserService-Migration.Dockerfile -t drmoz/userservice-migrations:v1 .<br />
docker push drmoz/userservice-migrations:v1<br /><br />

# install helm chart for User Service
 helm install user-svc ./deployment/charts/user-svc<br/>

# apply database migrations
kubectl apply -f ./deployment/user-svc-mssqldb.migrations.yaml<br/>

# call to check service health:<br/>
minikube service --url user-svc-app -n user-svc
curl -H'Host:arch.homework' -GET -i http://192.168.99.105/otusapp/IgorLopushko/health