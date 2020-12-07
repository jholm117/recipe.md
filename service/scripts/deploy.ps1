$imageName = "recipe.md"
$repoName = "jholm117/$imageName"

docker build . -t $repoName

docker push $repoName

# this needs resource group support
# az webapp container up `
#     --name recipe-md `
#     --docker-custom-image-name $repoName
