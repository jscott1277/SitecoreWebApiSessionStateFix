# SitecoreWebApiSessionStateFix
A pipeline to fix issues with session state when using a custom WebApi 2 service in Sitecore 8

# Intro
This pipeline was created to manage session state when Sitecore Analytics is enabled and a custom Web API is being used within the Sitecore instance.

# Installation
You can build this project and install the dll/config file manually, or download the Sitecore package from the Sitecore Marketplace:

https://marketplace.sitecore.net/Modules/W/Web_API_Session_State_Pipeline.aspx

# Configuration
There are two params in the config file that should be evaluated:
Web API Url - The Web Api Url to apply this pipeline against.
Session State Mode - The session mode to apply.
                 Valid values are: Default, Disabled, ReadOnly & Required
