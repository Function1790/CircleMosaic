   M S B A M L   `   `   `  ����B  >Palette, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PalettePalette  5          Palette.Window1   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      'paletteclr-namespace:Palette    5      >d2http://schemas.microsoft.com/expression/blend/2008    5   .   Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    6k     � Title$  Window1��6   $	��500��6   $	��700��6"    � 	Resources 5      !   Palette.ColorBrushConverter   ColorConverter   Palette.InkColorConverter  InkColorConverter��%:   &	        &	        5	   
   6&     5
   
   6$   5      .��5      �  � ColumnDefinitions 5      �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   .+�5   
   ]� $��0��6   $��1��6$   $��0��68   .+�5      o� $	��Top=�6   $��Stretch=�6(   $��1,1,1,1q�6F   ���	#FF000000.@�5      m� $
��File��6   .@�5      m� -   5        $
��Open��5      6-   m� 5      -   5        $
��Exit��5      6-   5      5        Palette.ImagePixelColor  5      -   5          Name$ Palette��5   ^   $��Palette.png��6&   $
��Fill=�6;   $��1��6J   $
��Left=�6o   5      �� 5   
   $��Stretch=�6   $��Stretch=�6/   $
��Auto��6K   $
��Auto��6X   ���	#FF000000$��2,2,2,2q�6~   $��0,0,0,0q�6�   $��1��6�   ��6�   Z� ._�5      �� -   5         ��Name$
 Memo��5      $
��Auto��6&   $
��Auto��63    �� 
Background �	#FFFFFFFF$��Stretch=�6X   $��Stretch=�6v    �� DefaultDrawingAttributes 5      ��  �� ElementName$ Palette�� �� Path$ CurrentColor�	 �� 	Converter#	 [ 6�   5       �� 5!   
   -   5        
 ��Name$
 	ColorView��5!   A   $��Right=�6   $��0,0,0,0q�60   $	��Top=�6T   $��50��6l   $��50��6w   ���	#FF000000$��1��6�   ��6�   �� $ Palette��$ CurrentColor�#	 [  6�   �� 5"   
   -   5        $��
textBlock1��5"   A   $��1��6   $��Right=�6$   $��Bottom=�6S   $��20(�6n   blog.naver.com/shine10ee6�   5#      5$      