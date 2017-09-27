# Introduction
Leverate Azure Functions to resize images uploaded to 'images' container.

# Deployment
1. Initiate deployment 
   
   [![Deploy to Azure](https://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmiartem%2FFunctions%2Fmaster%2FEXP.Functions%2FEXP.Functions.ImageResizer%2FDeployment%2Ftemplate.json) 

2. <div>
	<p>Set unique resource group name</p>
	<img src="Deployment%2FDocumentation%2FCustom%20deployment.PNG" width="600" title="Github Logo">
	</p>
   </div>
3. <div>
	<p>Wait for successful deployment</p>
	<img src="Deployment%2FDocumentation%2FResource%20group.PNG" width="600" title="Github Logo">
	</p>
</div>

# Usage

1. Create 'images' container
2. <div>
	<p>Upload image to 'images' container</p>
	<img src="Deployment%2FDocumentation%2FUpload%20image.PNG" width="600" title="Github Logo">
	</p>
</div>
3. Validate resized images in 'images-medium' and 'images-small' containers