   M S B A M L   `   `   `  ����I  EWpf_DeanSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Wpf_DeanSystemWpf_DeanSystem  5   	       Wpf_DeanSystem.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Wpf_DeanSystem     5   	   -   5          �Name$
  main��5   	    � Title$ 
MainWindow��5   	   $	��400��6   $	��550��6)    J� Effect 5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
   
   .��5      � $��
28,42,28,3q�6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��100��6:   $��1170,355,-291,-115q�6G   $	��Top=�6c   $	��100��6{   �� 5   
   $
��Left=�6   $	��284��6,   $	��Top=�69   $	��491��6Q   .+�5      �� -   5         ��Name$ textBox��5      $
��Left=�6'   $��38��6B    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $	��264��6z   $��24(�6�    �� Left$	 190��6�   
 �� Top$ 64��6�   �� 5      -   5        $ textBox2��5      $
��Left=�6(   $��38��6C   $
 Wrap=�6O   $	��Top=�6c   $	��264��6{   $��20(�6�   $	 190��6�   $	 136��6�   �� 5      -   5        	 ��Name$	 label2��5      $��PassWord��6$   $
��Left=�67   $	��Top=�6R   $��38��6j   $	��136��6v   $��22(�6�   $
��Bold"�6�   $ 49��6�   $	 136��6�   �� 5      -   5        $	 label��5      $��LanchID��6#   $
��Left=�65   $	��Top=�6P   $��38��6h   $	��136��6t   $��22(�6�   $
��Bold"�6�   $ 49��6�   $ 64��6�   �� 5      -   5        $	 label1��5      $��I am :��6$   $
��Left=�65   $	��Top=�6P   $��73��6h   $��33��6s   $��22(�6   $
��Bold"�6�   
 J� RenderTransformOrigin$
 0.138,0.438&�6�   $ 10��6�   $ 10��6�   �� 5      -   5         ��Name$ loginselect��5      $
��Left=�6,   $	��Top=�6G   $	��166��6_   $��33��6k   $��18(�6�   $
��Bold"�6�    �� MaxDropDownHeight$	 253��6�   $ 88��6�   $ 10��6�   .@�5      �� $��Student��6   $
��Left=�61   $	��118��6L   �� 5      -	   5        $��Teacher��5      $
��Left=�61   $	��118��6L   6X   �� 5      $��Administrator��6   $
��Left=�67   $	��148��6R   5      �� 5      -
   5         ��Name$ button��5      $��Login��6%   $
��Left=�65   $	��Top=�6P   $	��182��6h   $��68��6t   $��36(�6�   $
��Bold"�6�    �� 	IsDefault . $	 152��6�   $	 206��6�   5      5      5       