Sitecore Entity Service Demo Application
===================

A example Sitecore entity service application showing how to create a new service. Consume the service within a SPEAK application using the JavaScript API. Blog post on Entity Service available here. <http://mikerobbins.co.uk/2015/01/06/entityservice-sitecore-service-client/>

Project Setup
===================


The quickest way to setup this demo project is to download the Sitecore package in the releases and install this into your solution. This week give you all the SPEAK presentation details you require, along with the SPEAK JS and Entity Service compiled DLLs. ! 

# **Importing Sitecore SPEAK config:**

> - Clone the project .
> - Paste the serialisation folder into your Web root, sitecore application, data folder. 
> - Within the sitecore client, switch to the core database. Under Sitecore/client choose update tree from within the developer tab to import the serialisation (SPEAK application).  


# **Building Solution**

> - The solution is built on Visual Studio 2013
> - Reference the following Sitecore DLLs.
> - Sitecore.Kernel
> - Sitecore.Services.Client
> - Sitecore.Services.Core
> - Sitecore.Services.Infrastructure
> - Sitecore.Services.Infrastructure.Sitecore
