# CSharpFinalHomework-Cooperation
团队协作完成C#期末大作业
*********************
## 目录文件夹基本结构
  * **VideoPlayerAndManager** : 存放项目成品
  * **SQLite** : 存放与数据库操作相关的功能模块
  * **doc** : 存放项目相关的文档


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

* 使用：需要将VideoPlayerandManager文件夹中的两个dll文件添加到引用当中；皮肤的IrisSkin4.dll同样添加后还要把三个ssk文件放进主项目的bin/debug中

### 对于DBInterface和Sqlite的使用问题
* 需要重新添加对Sqlite库的依赖，在DBInterface项目下添加依赖项System.Data.SQLite.dll
* 运行前将test.db放在主项目的debug文件夹下，即.\VideoPlayerAndManager\VideoPlayerAndManager\bin\Debug

### 主界面的使用

* 双击打开视频
* 右键视频后可选择 收藏 或 填写备注 或 删除
* 点击扫描磁盘，选择对应的文件夹，将自动将文件夹中的视频存入数据库，并为本次添加的视频自动创建一个列表

### 视频列表的使用

* 点击新建列表——输入列表名称，点击确认添加，添加成功——在添加列表界面右键点击视频可添加进当前列表。
* 回到主界面，点击已添加的列表，进入列表详情界面——在列表名称框输入想要修改的名称，点击修改列表名称，修改列表名称成功。
* 在列表详情界面，选择“当前列表内视频”则展示当前列表内视频，右键点击视频可移出列表。在此情况下点击添加视频，则将把扫描的文件中的视频自动添加到当前列表。
* 在列表详情页，选择“全部视频”，展示已扫描过的全部视频，右键点击未在当前列表内的视频则可添加进当前列表，点击“添加视频”则将扫描的文件中的视频添加到“全部视频”中。
* 点击删除列表则删除当前列表（视频不删除，只是移出当前列表）

### 图片浏览按键的使用

* 点击按钮-选择带图片文件夹-根据缩略图点击浏览图片