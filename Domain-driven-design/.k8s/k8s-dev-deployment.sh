echo '----------------'
echo '----------------'
echo '----------------'
echo '----------------'
echo 'Make sure you have created loadbalancer and configured the notifications-allowed-origins located in development.yml config. If not run the following commands'
echo 'kubectl create service loadbalancer user-client --tcp=80:80'
echo 'kubectl edit service user-client and then change selector from app to web-client'
echo '----------------'
echo '----------------'
echo '----------------'

# 1. Apply environment
kubectl apply -f .environment/development.yml
sleep 1
echo 'Applied environment=development'

# 2. Apply databases
kubectl apply -f databases/database.yml
# 3. Apply event-bus
kubectl apply -f event-bus/event-bus.yml
echo 'Appling databases and event-bus ... '
sleep 10
echo 'Applied  data and event-bus!'

# 4. Apply web-services
kubectl apply -f web-services/identity-service.yml
kubectl apply -f web-services/foods-service.yml
kubectl apply -f web-services/cart-service.yml
echo 'Appling web-services ... '
sleep 10
echo 'Applied web-services!'

# 4.1 Build client image based on configuration

cd ..\client
docker build -t kristianlyubenov/petfoodshop-user-client-development:latest --build-arg configuration="development" .
docker push kristianlyubenov/petfoodshop-user-client-development:latest

# 5. Apply clients
kubectl apply -f clients/user-client.yml
echo 'Applied clients'
kubectl set image deployments/user-client user-client=kristianlyubenov/petfoodshop-user-client-development:latest
echo 'Changed user-client image to kristianlyubenov/petfoodshop-user-client-development:latest'
kubectl get pods

echo 'DONE!'
sleep 3