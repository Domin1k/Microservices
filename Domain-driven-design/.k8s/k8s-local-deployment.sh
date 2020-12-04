environment=local

# 1. Apply environment
kubectl apply -f .environment/$environment.yml
sleep .3
echo 'Applied environment=' + $environment

# 2. Apply databases
kubectl apply -f databases/database.yml
# 3. Apply event-bus
kubectl apply -f event-bus/event-bus.yml
echo 'Appling databases and event-bus ... '
sleep 3
echo 'Applied  data and event-bus!'

# 4. Apply web-services
kubectl apply -f web-services/
echo 'Appling web-services ... '
sleep 3
echo 'Applied web-services!'

# 5. Apply clients
kubectl apply -f clients/
echo 'Applied clients'

kubectl get pods