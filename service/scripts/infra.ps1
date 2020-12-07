$imageName = "recipe.md"
$repoName = "jholm117/$imageName"
$resourceGroupName = "appsvc_rg_linux_centralus"
$appName = "recipe-md"

az appservice plan create -n $imageName -g $resourceGroupName --is-linux --sku F1
az webapp create -n $appName -g $resourceGroupName -p $imageName -i $repoName
az webapp log config -n $appName -g $resourceGroupName --docker-container-logging filesystem
# manual steps:
# 1. add health check
