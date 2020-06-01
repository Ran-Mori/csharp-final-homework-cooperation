# CSharpFinalHomework-Cooperation
团队协作完成C#期末大作业
*********************
## 目录文件夹基本结构
  * **FinalProject** : 用于合并模块构建最后的成品项目
  * **SQLite** : 存放与数据库操作相关的功能模块

*************

### SQLite模块中对数据库的第一层封装 

* 简介：模块中重点类为SqLiteCRUD，它是一个**工具类**(类似java中的Utils)，实现**增删改查和创建**
* SqlLiteCRUD概况：
  * `SqLiteCRUD(string connectionString)` —— 构造方法，传入磁盘路径创建本地数据库
  * `SQLiteDataReader CreateTable(string tableName, string[] colNames, string[] colTypes)` —— 创建表
  * `SQLiteDataReader InsertValues(参数已省略)` —— 增加
  *  `SQLiteDataReader UpdateValues(参数已省略)` —— 修改
  * `SQLiteDataReader DeleteValuesAnd(参数已省略)` —— 删除
  *  `SQLiteDataReader ReadFullTable(string tableName)` —— 查询
* 环境依赖
  * .Net Framework 4.6.1
  * SqLite for .Net Framework 1.0.112.0 (3.30.1)
    * 使用方法，先安装dll库，项目中添加依赖，类中`using System.Data.SQLite;`

### 对于视频播放器的视频播放器dll和皮肤dll的问题

*使用：需要将VideoPlayerandManager文件夹中的两个dll文件添加到引用当中；皮肤的IrisSkin4.dll同样添加后还要把三个ssk文件放进主项目的bin/debug中