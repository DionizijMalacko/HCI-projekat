   M S B A M L   `   `   `  ����F  BHCIProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HCIProjekat.FormeHCIProjekat.Forme  5   	   ?$clr-namespace:HCIProjekat.ValidacijeHCIProjekat.Validacije  5   	   $    HCIProjekat.Forme.EtiketaForma   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   +localclr-namespace:HCIProjekat.Forme  5   	   .val$clr-namespace:HCIProjekat.Validacije  5   	     � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ Etiketa��5   	   $	��260��6   $	��400��6&   .��5      ]� .+�5   
   ]� $��Bottom=�6   
���OO/�.+�5      �� $��Bottom=�6   $��20��6,   6:   5      ]� 5   
   $	��Top=�6   $��Stretch=�6)   .+�5      � 
�����w� � ColumnDefinitions 5      �� 5      $	��21* �6'   �� 5      $
��422* �6'   .+�5      �� $	��ID:��6   $
��Left=�6&   $��10.2,19,0,0q�6A   $	��Top=�6V   $��1��6n   $��26��6~   $��53��6�   �� 5      -   5         ��Name$ id_txt��5       � ToolTip$O IObavezan unos oznake etikete. Dozvoljen unos slova, brojeva i donje crte.��6*   $
��Left=�6~   $��23��6�   $��100.6,19,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��265��6�   
�������$��1��6  .��6  ��5      �� 5       �� Path$ TxtId�6"    �� UpdateSourceTrigger$ PropertyChanged=�6/   	 �� Mode$	 TwoWay=�6U   
 �� ValidationRules
 5      .   (HCIProjekat.Validacije.ValidacijaTextBox  5   "   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 68   5       .��5!   $    =� ErrorTemplate 5"      �� 5#      .R�5$      �  � RowDefinitions 5%   "   �� 5&   &    5(   "   �� 5)   &   �� 5*   &   $
��Auto �67   .+�5-   "   ��  ��Name$ textBox��6Y   $��0��6<   $��0��6L   6Y   �� 5.   "   $��1��6,   $��0��6<   
���  ��$	��Top=�6|   $��22(�6�   $��Medium"�6�   ��6I   �� *[0].ErrorContent+6�   5/      50      .��51   0   52      �� 54      $��Opis:��6   $
��Left=�6(   $��10.2,62,0,0q�6C   $	��Top=�6X   $��1��6p   $��26��6�   $��37��6�   �� 55      -   5        $��opis_txt��55      $
��Left=�6P   $��46��6k   $��100.6,62,0,0q�6w   $
 Wrap=�6�   $	��Top=�6�   $	��265��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   
�������$��1��6�   ��6*   �� *	TxtOpis+$	 TwoWay=�6�   �� 59      $��Boja:��6   $
��Left=�6(   $	��Top=�6C   $��10.2,126,0,0q�6[   $��28��6q   $ 0.306,3.304&�6}   $��1��6�   $��35��6�   #  Xceed.Wpf.Toolkit.ColorPicker  5:      -   5        $��colorPicker��5:   #   $��100.6,126,0,0q�66   $��23��6M   $
��Left=�6Y   $	��Top=�6t      DisplayColorAndName . $��1��6�   $  Obavezan unos boje etikete��6�   $	��265��6   �� 5<      -   5        $��Odustani��5<      $
��Left=�6,   $��270.6,178,0,0q�6G   $	��Top=�6^   $��22��6v   $��95��6�   
�������$��1��6�   �� 5=      -   5        $��Sačuvaj��5=      $
��Left=�6+   $��100.2,177,0,0q�6F   $	��Top=�6]   $��23��6u   $��95��6�   
�������$��1��6�   5?      5@      5A      5B      