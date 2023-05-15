# WebApiDemo
## 项目介绍
  ### 1.ApiGateway  
    网关，使用Ocelot实现，结合Jwt进行应用的鉴权操作，还可以添加限流等操作  
  ### 2.WebApiDemo.Core  
    公共代码，领域层的抽象，公共仓储类等  
  ### 3.WebApiDemo.Domain  
    领域层，实体对象  
  ### 4.WebApiDemo.Infrastructure  
    基础设施层，主要实现了仓储相关代码和数据库的映射等  
  ### 5.WebApiDemo  
    应用层，api接口，使用MediatoR实现CQRS模式（命令与查询职责分离）  
    
