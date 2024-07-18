# To run the template 

> Need to create the resource group rg-mani 

```
az deployment group create --name azurestorage --resource-group rg-mani --template-file .\azuretemplate.json
```

with parameter

```
az deployment group create --name azurestorage --resource-group rg-mani --template-file ./azuretemplateparameter.json --parameters storageName=azurestoreg31910  storageAccountType=Standard_LRS
```

delete the storage account
```
az storage account delete -n azurestoreg31910 -g rg-mani
```
