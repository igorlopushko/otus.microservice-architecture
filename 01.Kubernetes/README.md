docker image for the simple service drmoz/aspnetapp

apply skaffold.yaml

call to check service health:
curl -H'Host:arch.homework' -GET -i http://192.168.99.102/otusapp/IgorLopushko/health