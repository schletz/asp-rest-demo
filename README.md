# Kubernetes Demo App

>> https://github.com/quarkus-seminar/2024-lab-minikube

## Voraussetzungen

*Minikube* und *kubectl* muss in der Konsole gefunden werden.

## Hochladen der App in die github container registry

Zuerst muss ein Token in github generiert werden. Dieser muss in docker login registriert werden:

```
echo <your_token> | docker login ghcr.io -u <your_github_user> --password-stdin
```

Gehe danach in das Verzeichnis *src*, erstelle das Docker Image und veröffentliche es.

```
docker build --tag ghcr.io/<your_github_user>/asp-rest-demo:latest . 
docker push ghcr.io/<your_github_user>/asp-rest-demo:latest
```

## Erstellen der Pods in Kubernetes

### Zurücksetzen von minikube

```
kubectl delete deployment --all
minikube delete
minikube start
```

## Erstellen der Pods

Wechsle danach in das Verzeichnis *k8s* und erstelle in Kubernetes die 2 Pods

```
kubectl apply -f postgres.yaml
kubectl apply -f appsrv.yaml
kubectl apply -f ingressasp-asp-rest-demo.yaml
```

Ändert sich das Image im github container repository, muss der Server neu gestartet werden:

```
kubectl delete -f ingressasp-asp-rest-demo.yaml
kubectl delete -f appsrv.yaml

kubectl apply -f appsrv.yaml
kubectl apply -f ingressasp-asp-rest-demo.yaml

kubectl rollout restart deployment asp-rest-demo
```

## Aktivieren des port forwardings

Liste die pods auf, um den Namen der Webapi herauszufinden:

```
kubectl get pods
```

Danach kann der Port 8080 zum Host weitergeleitet werden

```
kubectl port-forward asp-rest-demo-<your_id> 8080:8080
```

Auf *http://localhost:8080/swagger* kann die App nun gestartet werden.
Sie verwendet den Pod von Postgres über den Servicenamen (Host ist *postgres*).
