   M S B A M L   `   `   `  ����F  BHCIProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HCIProjekat.FormeHCIProjekat.Forme  5   	   ?$clr-namespace:HCIProjekat.ValidacijeHCIProjekat.Validacije  5   	   &     HCIProjekat.Forme.TipFormaUpdate   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HCIProjekat.Forme     5   	   4val$clr-namespace:HCIProjekat.Validacije     5   	     � 
ResizeMode$  NoResize=�5	   	    � Title$ Izmena Tipa��5
   	   $	��350��6   $	��500��6*    � WindowStartupLocation$ CenterScreen=�66   .��5      ]� .+�5   
   ]� $��Bottom=�6   
���OO/�.+�5      �� $��Bottom=�6   $��20��6,   $��Status bar:��68   $��9(�6N   6]   5      ]� 5   
   $	��Top=�6   $��Stretch=�6)   .+�5      � 
�����w�.+�5      �� $	��ID:��6   $
��Left=�6&   $��	34,23,0,0q�6A   $	��Top=�6T   �� 5      -   5        $��id��5       � ToolTip$L FObavezan unos oznake tipa, Dozvoljen unos slova, brojeva i donje crte.��6$   $
��Left=�6u   $��23��6�   $��
188,26,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��248��6�   
�������.��6  ��5      �� 5       �� Path$ TxtId�6"    �� UpdateSourceTrigger$ PropertyChanged=�6/    �� Mode$ TwoWay=�6U    �� ValidationRules 5      .   (HCIProjekat.Validacije.ValidacijaTextBox  5   "   ,  &System.Windows.Controls.ValidationRule	   ValidatesOnTargetUpdated	 . 68   5      .��5   $   
 =� ErrorTemplate
 5      �� 5      .R�5      �  � RowDefinitions 5   "   �� 5   &    � ColumnDefinitions 5    "   �� 5!   &   �� 5"   &   $
��Auto �67   .+�5%   "   ��  ��Name$ textBox��6Y   $��0��6<   $��0��6L   6Y   �� 5&   "   $��1��6,   $��0��6<   
���  ��$	��Top=�6|   $��22(�6�   $��Medium"�6�   ��6I   �� *[0].ErrorContent+6�   5'      5(      .��5)   0   5*      �� 5,      $
��Ime:��6   $
��Left=�6'   $��	34,66,0,0q�6B   $	��Top=�6U    J� RenderTransformOrigin$ -0.079,0.538&�6m   �� 5-      -   5        $	��ime��5-      $
��Left=�6%   $��23��6@   $
 Wrap=�6L   $	��Top=�6`   $	��248��6x   $��
188,66,0,0q�6�   
�������.��6�   ��5.      �� 5/      $ TxtIme�6"   $ PropertyChanged=�60   $ TwoWay=�6V    50        51   "   	 . 68   53      .��54   $   
 55      �� 56      .R�57      �  58   "   �� 59   &    5;   "   �� 5<   &   �� 5=   &   $
��Auto �67   .+�5@   "   �� $ textBox��6Y   $��0��6<   $��0��6L   6Y   �� 5A   "   $��1��6,   $��0��6<   
���  ��$	��Top=�6|   $��22(�6�   $��Medium"�6�   ��6I   �� *[0].ErrorContent+6�   5B      5C      .��5D   0   5E      �� 5G      $��Opis:��6   $
��Left=�6(   $��
34,106,0,0q�6C   $	��Top=�6W   �� 5H      -   5        $
��opis��5H      $
��Left=�6&   $��46��6A   $��188,106,0,0q�6M   $
 Wrap=�6b   $	��Top=�6w   $	��248��6�   
�������.��6�   ��5I      �� 5J      $ TxtOpis�6"   $ PropertyChanged=�61   $ TwoWay=�6W    5K        5L   "      ValidationStep$ RawProposedValue=�68   5N      .��5O   $   5P      �� 5R      $��Ikonica:��6   $
��Left=�6+   $��
34,194,0,0q�6F   $	��Top=�6Z   �� 5S      -   5        $��okvir��5S      ���	#FFF4F4F5$
��Left=�6:   $��63��6U   $��188,172,0,0q�6a   
���   �$	��Top=�6�   $	��130��6�   �� 5T      -   5        $��ikonica��5T      $
��Fill=�6(   $ Opcion unos slike tipa��67   $
��Left=�6X   $��63��6s   $��188,172,0,0q�6   $	��Top=�6�   $	��130��6�   �� 5U      
���   �$��1q�6-   $
��Left=�6A   $��63��6\   $��188,172,0,0q�6h   $	��Top=�6}   $	��130��6�   �� 5V      -   5        $��Izaberi ikonicu��5V      $ Opcion unos slike tipa��63   $
��Left=�6T   $��340,197,0,0q�6o   $	��Top=�6�   $��23��6�   $��96��6�   6�   �� 5Y      -   5        $��Sačuvaj��5Y      $
��Left=�6+   $��188,265,0,0q�6F   $	��Top=�6[   $��23��6s   $��95��6   
�������6�   �� 5Z      -   5        $��Odustani��5Z      $
��Left=�6,   $��341,265,0,0q�6G   $	��Top=�6\   $��23��6t   $��95��6�   
�������6�   5]      5_      5a      5b      