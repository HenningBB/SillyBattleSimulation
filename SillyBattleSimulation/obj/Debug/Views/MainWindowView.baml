   M S B A M L   `   `   `  ����P  LSillyBattleSimulation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SillyBattleSimulationSillyBattleSimulation  5   	   I)clr-namespace:SillyBattleSimulation.ViewsSillyBattleSimulation.Views  5   	   S.clr-namespace:SillyBattleSimulation.ViewModels SillyBattleSimulation.ViewModels  5   	   0    *SillyBattleSimulation.Views.MainWindowView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SillyBattleSimulation     5   	   ;Views)clr-namespace:SillyBattleSimulation.Views     5   	   E
ViewModels.clr-namespace:SillyBattleSimulation.ViewModels     5   	     � Title$  
MainWindow��5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62   $
��Auto��6W   $
��Auto��6e    � 	Resources 5       �� DataType:   4SillyBattleSimulation.ViewModels.SimulationViewModel0   *SillyBattleSimulation.Views.SimulationView@   :SillyBattleSimulation.ViewModels.VisualSimulationViewModel6   0SillyBattleSimulation.Views.VisualSimulationView5   /SillyBattleSimulation.ViewModels.WorldViewModel+   %SillyBattleSimulation.Views.WorldView9   3SillyBattleSimulation.ViewModels.CoolGraphViewModel/   )SillyBattleSimulation.Views.CoolGraphView4	   .SillyBattleSimulation.ViewModels.CityViewModel*
   $SillyBattleSimulation.Views.CityView��%w  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,	 +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " 	 6   .R�5      
  5      5      .��5      ]� .+�5   
   `� $	��Top=�6   .�5      c� .@�5       �� $��Switch��6   ��5!      �� *ChangeViewmodelCommand+�� 5"      $��World��6   ��5#      �� *DeployWorldCommand+�� 5$      $��Graph��6   ��5%      �� *GraphCommand+�� 5&      $
��City��6   ��5'      �� *CityCommand+5(      5)      �� 5*   
   $	��Top=�5,      $��Stretch=�5-      ��5+      �� *CurrentViewModel+5-      5.      5/      