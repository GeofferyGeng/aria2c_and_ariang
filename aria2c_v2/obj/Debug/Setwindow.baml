   M S B A M L   `   `   `  ����D  @aria2c_v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:aria2c_v2	aria2c_v2  5   	       aria2c_v2.Setwindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:aria2c_v2     5   	     � 
ResizeMode$  NoResize=�5   '    � WindowStyle$
 None=�6=   $��1q�6P   
������� � Title$ 	Setwindow��5   	   $	��400��6   $	��600��6(   .��5	      � .+�5
   
   � .+�5      � -   5        ���#CCCCCC$	��Top=�5   L   $��0,0,0.4,366.4q�6a   .+�5      �� -   5         ��Name$ txtTitle��5      $��1,0,0,0q�6.    �� Padding$ 5,3,2,3q�6@   $�� Aria2配置��6R   $
��Left=�5      $	��Top=�6/   $��16(�6G   $��微软雅黑)�6U   
�������$��32��6z   $��95��6�   5      �� 5      $��pic\close.png��6   $��23��6+   $��24��67   $��Right=�6B   $	��Top=�6^   $��0,5,10,0q�6v   6�   �� 5      $��pic\min.png��6   $��23��6)   $��23��65   $��Right=�6@   $	��Top=�6\   $��0,6,51,0q�6t   6�   �� 5      -   5         ��Name$ closebuttonset��5      $��30��6-   $��40��69   $��Right=�6D   $	��Top=�6`   
������ $��0q�6�   $��0,2,3,0q�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value �#CCCCCC67   	 �� Triggers	 5      P� 5      
 P� Property
 �@J�IsMouseOver P� Value . . �5   "   ��  � �� 5   &   �� 5   *   .R�5   .   �� ���	#6666666668   5   +   5   #   5      5       5"      �� 5#      -   5        $ minbuttonset��5#      $��30��6+   $��40��67   $��Right=�6B   $	��Top=�6^   
������ $��0,2,43,0q�6�   $��0q�6�   ��5$      �� 5%      " ��6   .�5&      ��  � �� �#dd114467   	 5'      P� 5(      
 �@J�IsMouseOver . . �5)   "   ��  � �� 5*   &   �� 5+   *   .R�5,   .   �� ���	#6666666668   5-   +   5/   #   50      52      54      �� 56       �� CornerRadius$ 15��6   $	��1.5q�6(   
�������$
��Left=�6Q   $	��309��6l   $��	26,53,0,0q�6y   $	��Top=�6�   $	��543��6�   ._�57      � .+�58      ��  � ToolTip$! 下载文件的保存位置��6    $��15(�64   $
��Left=�6B   $��	34,20,0,0q�6]   $
��Wrap=�6p   $��下载路径：��6�   $	��Top=�6�   $��89��6�   �� 59      -   5         ��Name$ t_dir��59      $��17(�6-   $��22��6;   $��109,19,115.2,0q�6G   $	��Top=�6_   
���� K�$��0��6�   $��1q�6�   .��6�    � 	Resources 5:         	HelpBrush j� TileMode �� Opacity j� Stretch j� 
AlignmentX !� Visual��%�   &	        !� 5;      $
 None=�6<   $	 0.3Q�6L   $
 None=�6Z   $
 Left=�6i    5<   "   �� 5=   &   $��Italic$�60   $��10(�6C   $��默认 D:\download��6Q   5?      5@      .��6-   ��5A      �� 5B      " ��6$   	 5C   "   P� 5D   &   
 � �� 6>   Z� . �5E   *   ��  � ��# [  6G   5F   '   P� 5G   &   
 � ��$  ��6>   . �5H   *   ��  � ��# [  6G   5I   '   5K      .��5L   )   5M      �� 5N      -   5        $ 	file_path��5N      $��浏览��60   ���	#64CCCCCC$
��Left=�6U   $��
440,20,0,0q�6p   $	��Top=�6�   $��43��6�   $��20��6�   6�   �� 5Q      -   5        $ t_split��5Q      $��17(�6/   $��22��6=   $��110,70,368.2,0q�6I   $	��Top=�6a   
���� K�$��0��6�   $��1q�6�   .��6�    5R      ��%�   &	        !� 5S      $
 None=�6<   $	 0.3Q�6L   $
 None=�6Z   $
 Left=�6i    5T   "   �� 5U   &   $��Italic$�60   $��10(�6C   $��
默认 128��6Q   5W      5X      .��6-   ��5Y      �� 5Z      " ��6$   	 5[   "   P� 5\   &   
 � �� 6>   Z� . �5]   *   ��  � ��# [  6G   5^   '   P� 5_   &   
 � ��$  ��6>   . �5`   *   ��  � ��# [  6G   5a   '   5c      .��5d   )   5e      �� 5f      $? 9一个任务连接的资源数量，并不是越大越好��6    $
��Left=�6>   $��	34,70,0,0q�6Y   $
��Wrap=�6l   $��最大连接：��6�   $��15(�6�   $	��Top=�6�   �� 5h      -   5        $ t_maxconcurrentdownloads��5h      $��17(�6@   $��22��6N   $��110,105,367.2,0q�6Z   $	��Top=�6s   
���� K�$��0��6�   $��1q�6�   .��6�    5i      ��%�   &	        !� 5j      $
 None=�6<   $	 0.3Q�6L   $
 None=�6Z   $
 Left=�6i    5k   "   �� 5l   &   $��Italic$�60   $��10(�6C   $��默认 3��6Q   5n      5o      .��6-   ��5p      �� 5q      " ��6$   	 5r   "   P� 5s   &   
 � �� 6>   Z� . �5t   *   ��  � ��# [  6G   5u   '   P� 5v   &   
 � ��$  ��6>   . �5w   *   ��  � ��# [  6G   5x   '   5z      .��5{   )   5|      �� 5}      $$ 同时进行的任务最大值��6    $
��Left=�65   $��
34,105,0,0q�6P   $
��Wrap=�6d   $��并行下载：��6x   $��15(�6�   $	��Top=�6�   �� 5      -	   5        $ t_maxdownloadlimit��5      $��17(�6:   $��22��6H   $��110,140,368.2,0q�6T   $	��Top=�6m   
���� K�$��0��6�   $��1q�6�   .��6�    5�      ��%�   &	        !� 5�      $
 None=�6<   $	 0.3Q�6L   $
 None=�6Z   $
 Left=�6i    5�   "   �� 5�   &   $��Italic$�60   $��10(�6C   $��0为不限速��6Q   5�      5�      .��6-   ��5�      �� 5�      " ��6$   	 5�   "   P� 5�   &   
 � �� 6>   Z� . �5�   *   ��  � ��# [  6G   5�   '   P� 5�   &   
 � ��$  ��6>   . �5�   *   ��  � ��# [  6G   5�   '   5�      .��5�   )   5�      �� 5�      $$ 所有下载任务的总限速��6    $
��Left=�65   $��
34,140,0,0q�6P   $
��Wrap=�6d   $��下载限速：��6x   $��15(�6�   $	��Top=�6�   �� 5�      -
   5        $ t_minsplitsize��5�      $��17(�66   $��22��6D   $��110,175,368.2,0q�6P   $	��Top=�6i   
���� K�$��0��6�   $��1q�6�   .��6�    5�      ��%�   &	        !� 5�      $
 None=�6<   $	 0.3Q�6L   $
 None=�6Z   $
 Left=�6i    5�   "   �� 5�   &   $��Italic$�60   $��10(�6C   $��	默认 2M��6Q   5�      5�      .��6-   ��5�      �� 5�      " ��6$   	 5�   "   P� 5�   &   
 � �� 6>   Z� . �5�   *   ��  � ��# [  6G   5�   '   P� 5�   &   
 � ��$  ��6>   . �5�   *   ��  � ��# [  6G   5�   '   5�      .��5�   )   5�      �� 5�      $� �把一个任务分成很多块以并行下载，此为每个块的最小体积，如设置为2M，则一个10M的文件最多分为5块��6    $
��Left=�6\   $��
35,175,0,0q�6w   $
��Wrap=�6�   $��分块大小：��6�   $��15(�6�   $	��Top=�6�   �� 5�      -   5        $ 
t_continue��5�      $��17(�62   $��22��6@   $��110,210,359.2,0q�6L   $	��Top=�6e   
���� K�$��0��6�   $��1q�6�   .��6�    5�      ��%�   &	        !� 5�      $
 None=�6<   $	 0.3Q�6L   $
 None=�6Z   $
 Left=�6i    5�   "   �� 5�   &   $��Italic$�60   $��10(�6C   $��默认 true��6Q   5�      5�      .��6-   ��5�      �� 5�      " ��6$   	 5�   "   P� 5�   &   
 � �� 6>   Z� . �5�   *   ��  � ��# [  6G   5�   '   P� 5�   &   
 � ��$  ��6>   . �5�   *   ��  � ��# [  6G   5�   '   5�      .��5�   )   5�      �� 5�      $* $停止后重新开始时继续下载��6    $
��Left=�67   $��
34,210,0,0q�6R   $
��Wrap=�6f   $��15(�6z   $	��Top=�6�   $��断点续传:��6�   6�   �� 5�      -   5        $��set_ok��5�      $��确认��6+   $
��Left=�68   $��
34,254,0,0q�6S   $	��Top=�6g   $��70��6   $��30��6�   ��5�      �� 5�       �� 
TargetType" ��6.   .R�5�   "   �� $��PART_Background��6�   #��z��6)   $��0q�6]   $ 5,5,5,5��6q   ��5�   &   �� 5�   *    �� EndPoint$	 0,1&�6>    �� 
StartPoint$	 0,0&�6M   .��5�   .   �  � Color$ #DCDCDC��6;    � Offset$	 0.5Q�6K   5�   +   ._�5�   &   �� #��z��67   $��Center=�6j   $��Center=�6�   5�   #    �� Triggers 5�   "   P� 5�   &   
 �@J�IsMouseOver . . �5�   *   ��  �� 
TargetName$ PART_Background��6N    � �� 5�   .   �� 5�   2   $	 0,1&�6F   $	 0,0&�6U   .��5�   6   � $ 	#66666666��6C   $	 0.0Q�6U   5�   3   5�   +   5�   '   5�      5�      �� 5�      -   5        $��
set_cancel��5�      $��取消��6/   $
��Left=�6<   $��125,254,0,0q�6W   $	��Top=�6l   $��70��6�   $��30��6�   ��5�      �� 5�      " ��6.   .R�5�   "   �� $��PART_Background��6�   #��z��6)   $��0q�6]   $ 5,5,5,5��6q   ��5�   &   �� 5�   *   $	 0,1&�6>   $	 0,0&�6M   .��5�   .   � $ #DCDCDC��6;   $	 0.5Q�6K   5�   +   ._�5�   &   �� #��z��67   $��Center=�6j   $��Center=�6�   5�   #    5�   "   P� 5�   &   
 �@J�IsMouseOver . . �5�   *   �� $ PART_Background��6N    � �� 5�   .   �� 5�   2   $	 0,1&�6F   $	 0,0&�6U   .��5�   6   � $ #F08080��6C   $	 0.0Q�6S   5�   3   5�   +   5�   '   5�      5�      �� 5�      
�������$	��1.5q�60   $ 10��6F   $��254,61,31.2,28.8q�6X   ._�5�      � .+�5�      �� -   5        $ t_diskcache��5�   &   $��17(�6;   $��22��6I   $��143,30,24.2,0q�6U   $	��Top=�6l   
���� K�$��0��6�   $��1q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   .��6�    5�   "   ��%�   &	        !� 5�   &   $
 None=�6D   $	 0.3Q�6T   $
 None=�6b   $
 Left=�6q    5�   *   �� 5�   .   $��Italic$�68   $��10(�6K   $��
默认 32M��6Y   5  '   5  #   .��65   ��5  "   �� 5  &   " ��6,   	 5  *   P� 5  .   
 � �� 6F   Z� . �5  2   ��  � ��# [  6O   5  /   P� 5	  .   
 � ��$  ��6F   . �5
  2   ��  � ��# [  6O   5  /   5  '   .��5  1   5     �� 5     $Q K启用磁盘缓存, 0为禁用缓存，改小且立即应用时会报错！��6(   $��磁盘缓存体积：��6N   $
��Left=�6]   $��	16,30,0,0q�6x   $
��Wrap=�6�   $��15(�6�   $	��Top=�6�   6�   �� 5     -   5        $ t_fileallocation��5  &   $��17(�6@   $��22��6N   $��143,60,24.2,0q�6Z   $	��Top=�6q   
���� K�$��0��6�   $��1q�6�   .��6�    5  "   ��%�   &	        !� 5  &   $
 None=�6D   $	 0.3Q�6T   $
 None=�6b   $
 Left=�6q    5  *   �� 5  .   $��Italic$�68   $��10(�6K   $��默认 falloc��6Y   5  '   5  #   .��65   ��5  "   �� 5  &   " ��6,   	 5  *   P� 5  .   
 � �� 6F   Z� . �5  2   ��  � ��# [  6O   5  /   P� 5   .   
 � ��$  ��6F   . �5!  2   ��  � ��# [  6O   5"  /   5$  '   .��5%  1   5&     �� 5'     $z t能有效降低磁盘碎片, NTFS建议使用falloc,预分配所需时间: none小于falloc小于trunc小于prealloc��6(   $
��Left=�6s   $��	16,60,0,0q�6�   $
��Wrap=�6�   $��15(�6�   $	��Top=�6�   $��文件预分配方式:��6�   6�   �� 5*     -   5        $ t_seedratio��5*  &   $��17(�6;   $��22��6I   $��143,90,24.2,0q�6U   $	��Top=�6l   
���� K�$��0��6�   $��1q�6�   .��6�    5+  "   ��%�   &	        !� 5,  &   $
 None=�6D   $	 0.3Q�6T   $
 None=�6b   $
 Left=�6q    5-  *   �� 5.  .   $��Italic$�68   $��10(�6K   $��默认 1��6Y   50  '   51  #   .��65   ��52  "   �� 53  &   " ��6,   	 54  *   P� 55  .   
 � �� 6F   Z� . �56  2   ��  � ��# [  6O   57  /   P� 58  .   
 � ��$  ��6F   . �59  2   ��  � ��# [  6O   5:  /   5<  '   .��5=  1   5>     �� 5?     $1 +bt任务文件做种比例.0为一直做种��6(   $
��Left=�6D   $��	16,90,0,0q�6_   $
��Wrap=�6r   $��bt任务做种率：��6�   $��15(�6�   $	��Top=�6�   �� 5B     -   5        $ t_followtorrent��5B  &   $��17(�6?   $��22��6M   $��143,120,24.2,0q�6Y   $	��Top=�6q   
���� K�$��0��6�   $��1q�6�   .��6�    5C  "   ��%�   &	        !� 5D  &   $
 None=�6D   $	 0.3Q�6T   $
 None=�6b   $
 Left=�6q    5E  *   �� 5F  .   $��Italic$�68   $��10(�6K   $��默认 true��6Y   5H  '   5I  #   .��65   ��5J  "   �� 5K  &   " ��6,   	 5L  *   P� 5M  .   
 � �� 6F   Z� . �5N  2   ��  � ��# [  6O   5O  /   P� 5P  .   
 � ��$  ��6F   . �5Q  2   ��  � ��# [  6O   5R  /   5T  '   .��5U  1   5V     �� 5W     $= 7当下载文件以。torrent结尾时自动下载文件��6(   $
��Left=�6J   $��
16,120,0,0q�6e   $
��Wrap=�6y   $��15(�6�   $	��Top=�6�   $��bt任务自动下载��6�   6�   �� 5Z     -   5        $ t_btmaxpeers��5Z  &   $��17(�6<   $��22��6J   $��143,150,24.2,0q�6V   $	��Top=�6n   
���� K�$��0��6�   $��1q�6�   .��6�    5[  "   ��%�   &	        !� 5\  &   $
 None=�6D   $	 0.3Q�6T   $
 None=�6b   $
 Left=�6q    5]  *   �� 5^  .   $��Italic$�68   $��10(�6K   $��
默认 256��6Y   5`  '   5a  #   .��65   ��5b  "   �� 5c  &   " ��6,   	 5d  *   P� 5e  .   
 � �� 6F   Z� . �5f  2   ��  � ��# [  6O   5g  /   P� 5h  .   
 � ��$  ��6F   . �5i  2   ��  � ��# [  6O   5j  /   5l  '   .��5m  1   5n     �� 5o     $K E单个文件种子的最多连接数，256已经足够，限制未知��6(   $
��Left=�6L   $��
16,150,0,0q�6g   $
��Wrap=�6{   $��15(�6�   $	��Top=�6�   $��bt种子连接数:��6�   6�   �� 5r     -   5        $ t_enabledht��5r  &   $��17(�6;   $��22��6I   $��143,180,24.2,0q�6U   $	��Top=�6m   
���� K�$��0��6�   $��1q�6�   .��6�    5s  "   ��%�   &	        !� 5t  &   $
 None=�6D   $	 0.3Q�6T   $
 None=�6b   $
 Left=�6q    5u  *   �� 5v  .   $��Italic$�68   $��10(�6K   $��默认 true��6Y   5x  '   5y  #   .��65   ��5z  "   �� 5{  &   " ��6,   	 5|  *   P� 5}  .   
 � �� 6F   Z� . �5~  2   ��  � ��# [  6O   5  /   P� 5�  .   
 � ��$  ��6F   . �5�  2   ��  � ��# [  6O   5�  /   5�  '   .��5�  1   5�     �� 5�     $&  DHT功能，pt任务需要禁用��6(   $��bt任务DHT功能：��6A   $
��Left=�6S   $��
16,180,0,0q�6n   $
��Wrap=�6�   $��15(�6�   $	��Top=�6�   6�   5�     5�     �� 5�     
�������$
��Left=�63   $��
339,53,0,0q�6N   $
��Wrap=�6b   $��16(�6v   $��  高级设置  ��6�   ���#00BFFF$��微软雅黑)�6�   $	��Top=�6�   $ 进阶设置��6�   5�     5�     �� 5�     $
��Left=�6   $��
60,376,0,0q�63   $
��Wrap=�6G   $0��*注：请确保您掌握正确的格式！��6[   $��10(�6q   
���  ��$	��Top=�6�   $	��509��6�   5�     5�     5�     