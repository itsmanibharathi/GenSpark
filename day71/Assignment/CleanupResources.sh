#!/bin/bash

RESOURCE_GROUP="rg-mani"

az group delete --name $RESOURCE_GROUP --yes --no-wait
