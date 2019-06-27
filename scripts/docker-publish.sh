#!/bin/bash
DOCKER_TAG='latest'
docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
docker build -t accoon.pitstop.vehiclemanagement:$DOCKER_TAG src/Pitshop.VehicleApi/Accoon.Pitshop.VehicleApi.Presenter
docker tag accoon.pitstop.vehiclemanagement:$DOCKER_TAG $DOCKER_USERNAME/accoon.pitstop.vehiclemanagement:$DOCKER_TAG
docker push $DOCKER_USERNAME/accoon.pitstop.vehiclemanagement:$DOCKER_TAG