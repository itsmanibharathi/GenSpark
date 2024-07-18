#!/bin/bash

# Variables
RESOURCE_GROUP="rg-mani"
LOCATION="eastus"
SQL_SERVER_NAME="sqlserver-mani"
ADMIN_USERNAME="myAdminUser"
ADMIN_PASSWORD="myAdminPassword123!"
KEY_VAULT_NAME="keyvault-mani"

# Create Resource Group
# az group create --name $RESOURCE_GROUP --location $LOCATION
az deployment sub create --location $LOCATION --template-file ResourceGroupTemplate.json --parameters location=$LOCATION resourceGroupName=$RESOURCE_GROUP


# Deploy SQL Server Template
az deployment group create \
  --name DeploySQLServer \
  --resource-group $RESOURCE_GROUP \
  --template-file SQLServerTemplate.json \
  --parameters sqlServerName=$SQL_SERVER_NAME adminUsername=$ADMIN_USERNAME adminPassword=$ADMIN_PASSWORD location=$LOCATION

# Deploy Key Vault Template
az deployment group create \
  --name DeployKeyVault \
  --resource-group $RESOURCE_GROUP \
  --template-file KeyVaultTemplate.json \
  --parameters keyVaultName=$KEY_VAULT_NAME sqlServerName=$SQL_SERVER_NAME adminUsername=$ADMIN_USERNAME adminPassword=$ADMIN_PASSWORD location=$LOCATION

