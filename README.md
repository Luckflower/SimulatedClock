## 模拟时钟 ##

**模拟时钟** GDI绘制，并且利用双缓冲去除了图形的闪烁
    
### 一.思路：###
1.画表盘

		包括：表盘中心，指针，刻度，背景图片

2.添加timer控件

将核心代码(主要是利用GDI做图和双缓冲)放在timer控件的Tick事件中，这样当timer开启时模拟时钟就会动起来，并且时间间隔为Interval：1000，即1s

3.双缓冲

由于时钟没走一秒钟，整个图形都要重新绘制一次，这就导致时钟会不停的闪烁，为了解决此问题，引入了双缓冲

		private BufferedGraphics bGrp;//新建图形的双缓冲区

		Graphics grp = bGrp.Graphics;//将Graphics输入到缓冲区

		this.bGrp.Render();//输出缓冲区的内容



### 运行结果:###
	
![test](http://ww1.sinaimg.cn/mw690/b0c67581gw1ek2r4yq6ggj20h10d5zlk.jpg)

