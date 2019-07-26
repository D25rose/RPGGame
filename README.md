# RPGGame
单机RPG游戏Demo。包含角色系统，背包系统，技能系统，任务系统，商店系统，战斗系统，物品合成系统和存档系统。

UI逻辑即非战斗场景代码主要在MyGame2/Assets/Scripts/02目录下

战斗场景的代码主要在MyGame2/Assets/Scripts/01目录下

其他一些共用代码就在MyGame2/Assets/Scripts目录下

存档系统中 新游戏 功能没有开发，尽量使用 继续游戏 进入游戏

游戏数据保存在Json文件中，由于经过存档，数据由系统写入过，Json文件中的中文无法显示，可以将Json文本复制到Json解析器中解析，即可查看真正的文本内容
