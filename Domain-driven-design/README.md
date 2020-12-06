# Run PetFoodShop (DDD approach) via Kubernetes #

Navigate to Domain-driven-design\.k8s and run sh k8s-local-deployment.sh to run it under local k8s cluster

IMPORTANT.
Due to limitations of Google Cloud Free Trial only 4 external IP could be used (among all projects atm)
Therefore only 4 services are deployed
- User-client 
- Identity microservice
- Foods microservice
- Cart microservice

UI can be accessed at - http://104.155.180.245/        

NOTE. 
This cluster will be stopped after 10.12.2020