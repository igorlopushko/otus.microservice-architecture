docker image for the simple service "drmoz/aspnetapp:v1"<br/>

apply skaffold.yaml<br/>

call to check service health:<br/>
curl -H'Host:arch.homework' -GET -i http://192.168.99.102/otusapp/IgorLopushko/health
