   M S B A M L   `   `   `  ����C  ?BoxGames, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BoxGamesBoxGames  5   	       BoxGames.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:BoxGames     5   	     � Title$  	Box Games��5   	   $	��238��6   $	��410��6(    � WindowStyle$ 
ToolWindow=�64    � Icon$ iconmonstr-view-5.ico��6M   .��5	      � -   5        $��gridMain��5	       � ColumnDefinitions 5
   
   �� 5      $	��200 �6   6-   �� 5      $	��200 �6   6-    � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   .+�5   
   �� -   5        $��butStartClear��5      $��0��6&   $��0��63   ��5      �� 5       �� Color# � ��6"   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color# � ��6#   	 � Offset$	 1Q�6o   � 5      $ Green��6#   5      ��5      �� 5      -   5        $��spButStartClear��5      
 �� Orientation$
 Vertical=�64   .+�5      �� -   5        $��imgButStartClear��5      $/��)images/iconmonstr-construction-24-240.png��64   $��75��6g   �� 5      -   5        $��tbButStartClear��5       $��Clear Boxes��67   $
��Bold"�6J   $��Center=�6\   6{   5       5"      �� 5#   
   -   5        $��butStartTimed��5#      $��0��6&   $��1��63   ��5$      �� 5%      $ 0.5,1&�6&   $ 0.5,0&�67   .��5&      � # � ��6#   $	 1Q�6o   � 5'      $	 Red��6#   5(      ��5*      �� 5+      $ 0.5,1&�6&   $ 0.5,0&�67   .��5,      � $ Black��6#   $	 0Q�61   � 5-      # � ��6#   $	 1Q�6o   5.      ��50      �� 51      -   5        $��spButStartTimed��51      $
 Vertical=�64   .+�52      �� -   5        $��imgButStartTimed��52      $'��!images/iconmonstr-time-19-240.png��64   $��75��6_   �� 53      -	   5        $��tbButStartTimed��53       $��Timed Boxes��67   $
��Bold"�6J   $��Center=�6\   6{   54      56      �� 57   
   -
   5        $��butStartVert��57      $��1��6%   $��0��62   ��58      �� 59      $ 0.5,1&�6&   $ 0.5,0&�67   .��5:      � # � ��6#   $	 0Q�6k   � 5;      $ White��6#   $	 1Q�61   5<      ��5>      �� 5?      -   5        $��spButStartVert��5?      $
 Vertical=�63   .+�5@      �� -   5        $��imgButStartVert��5@      $)��#images/iconmonstr-upload-10-240.png��63   $��75��6`   �� 5A      -   5        $��tbButStartVert��5A       $��Vertical Boxes��66   $
��Bold"�6L   $��Center=�6^   6}   5B      5D      �� 5E   
   -   5        $��butQuit��5E      $��1��6    $��1��6-   ��5F      �� 5G      $ 0.5,1&�6&   $ 0.5,0&�67   .��5H      � # � ��6#   $	 0Q�6j   � 5I      $ White��6#   $	 1Q�61   5J      ��5L      �� 5M      -   5        $��	spButQuit��5M      $
 Vertical=�6.   .+�5N      �� -   5        $��
imgButQuit��5N      $)��#images/iconmonstr-log-out-1-240.png��6.   $��75��6[   �� 5O      -   5        $��	tbButQuit��5O       $��	Quit Game��61   $
��Bold"�6B   $��Center=�6T   6s   5P      5R      5S      5T      