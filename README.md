
# The DEV-ON time Platform for the .NET stack

- [Features](#features)
- [What sets devon4net apart?](#what-sets-devon4net-apart)
- [What does devon4net include?](#what-does-devon4net-include)
    - [Templates](#templates)
    - [NuGet packages](#nuget-packages)
    - [Complete documentation](#complete-documentation)


_NOTE: This is a .net 8 branch. The .net 8 is in RC Status. Please do not use this version/branch for production environments. devon4net only uses LTS versions_
Devon4Net is part of the devonfw free and open source framework for the .NET stack. It provides a solid architectural model based on *Onion Layered Design* for building cloud native solutions, microservices, WebAPI applications and protocol buffers (protobuf) applications.

Devon4net is intended for building backend applications.
However denvonfw also has tools to build frontend client applications such as devon4ng. 

## Features

* ***Clean Layered Architecture***: 
The architecture is separated in different components, using the onion architecture pattern. Finding the balance between best practices and latest trends, and a short learning curve that helps us scale up and be productive.

* ***Modular & Easily Configurable***:
All functionalities are built to work as individual and configurable components via 'appsettings.json'. That means you can use them separately or even use all of them in a single application.

* ***NuGet support***:
Every component can be used isolated as a package via Nuget in any .NET application, without the need of using any devon template.

* ***AWS templates integration***:
The devon4net project has different ready to use templates. This samples include Cloud Native, Kafka and Web API solutions.
* ***Free & Open Source***:
Devon4net is actively being developed on GitHub (Apache-2.0 license) and accepting contributions. This gives developers complete access to the source code.

* ***gRPC and protocol buffers support***:
The supplied templates will allow you to easily construct standardized gRPC clients and services, or simply add gRPC support to your existing services.

## What sets devon4net apart?

* ***Productivity:*** The first step when starting a new project is to arrange the structure and implement the common components to make it work properly. But, why code it when you can just reuse it? You can skip this part and go straight to coding specialized components, leaving the common stuff to devon4net collaborators.

* ***Steep learning curve:*** When setting up this kind of technology, the key challenge is adjusting how team members perform to include its use. This can be counterproductive in some circumstances, since the time spent learning how to use them may be greater than the total time saved using them. As a result, one of our primary goals is to provide an easy-to-use and learn format so that implementation may be completed as quickly as possible.

* ***Code quality:*** We have a "0 errors, 0 warnings, 0 messages" policy when developing new features and functionalities in the solution. The usage of design patterns, well-known architectures, and best practices across the code has resulted in a clean code masterpiece, using tools such as SonarQube to scan the lines looking for bugs and code smells.

* ***Support & Mantainance:*** Behind the code, a large team of experts with years of experience in the field develop new features and provide support to the community helping to solve any type of issue.

* ***Integrated templates:*** You may use the template to develop a microservice solution with minimum setup. Furthermore, the devon4Net framework may be integrated into third-party templates such as the Amazon API template to enable the use of lambdas in serverless environments

## What does devon4net include?




### Templates
As mentioned before, devon4net includes a number of ready to use templates, they can be used thanks to the package manager NuGet. These templates provide you with a base structure and some classes that simplify the creation process:

* *Web APIs*
* *AWS* cloud solutions
* *gRPC* clients and services
* *Kafka* event streaming platforms

More info about these topics and how to use them will be displayed in the documentation.

### NuGet packages
You will discover a mix of useful NuGet packages that are up to date as well as ones that are deprecated but may still be used. They will assist you in recycling common features across projects. Each package can easily be configured to suit your preferences. 

Explore the packages in the [NuGet gallery](https://www.nuget.org/packages?q=devonfw).

### Complete documentation
The documentation contains all the information you need to use the different packages and templates together with videos and "how to" tutorials. Do not hesitate to review the documentation and consider asking the team any questions if necessary. 

Explore the documentation in the [Wiki](https://github.com/devonfw/devon4net/wiki) or [site documentation](https://devonfw.com/website/pages/docs/devonfw-guide_devon4net.wiki_master-devon4net.asciidoc.html).