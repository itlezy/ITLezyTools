## IT Lezy Tools
A collection of IT tools meant for the IT geek, admins and developers

### QuickManager
An integrated process manager, where custom environments and commands can be defined. Integrated output viewer, task manager, editor, and much more.
This tool is designed to help developers and admins who need to run processes, such as Tomcat, with different environment sets, parameters, configuration files, and monitor the output in a tail fashion.
Ideal for developers, who needs to run batches, builds, application servers, services, and much more.
Launches can be set to automatic, cascaded, stopped and monitored. URL monitoring is included, to check for web applications availability and remote web-sites.

#### QuickManager Main Window

![QM](https://itlezy.github.io/images/QuickManager02.png)

#### Integrated Configuration Editing

![QM](https://itlezy.github.io/images/QuickManager01.png)

#### Configuration
Items can be monitor items, to be monitored as HTTP services..

```xml
    <monitorItem id="Tomcat">
      <url>http://localhost:8080/Some/Servlet.do</url>
    </monitorItem>
```

..or be actions, or both. In this case a 'Tomcat' is an item to monitor, with an associated launch.
A specific environment 'JAVA6' is specified.

```xml
    <!-- To have both a monitor item and an action, use the same id -->
    <!-- startAll="true" to launch or stop with SHIFT+F2 -->
    <action id="Tomcat" startAll="true">
      <launch env="JAVA6">
        <exe>c:\bin\apache-tomcat-6.0.41\bin\catalina.bat</exe>
        <parms>run</parms>
      </launch>
    </action>
```

Environments can be named, in order to allow multiple environments to be defined.

```xml
  <!-- Envs can be named -->
  <env id="JAVA6">
    <vars>
      <var>
        <name>ANT_HOME</name>
        <value>c:\bin\apache-ant-1.7.1</value>
      </var>
      <var>
        <name>JAVA_HOME</name>
        <value>C:\bin\java6\32bit\jdk1.6.0_30</value>
      </var>
      <var>
        <name>CATALINA_HOME</name>
        <value>c:\bin\apache-tomcat-6.0.41</value>
      </var>      
      <var>
        <name>PATH</name>
        <value>%ANT_HOME%\bin;%JAVA_HOME%\bin;%SystemRoot%\system32;%SystemRoot%</value>
      </var>
    </vars>
  </env>
```

### OutputViewer
A multi tail for Windows, designed to follow log files, highlight, search, and much more. Give it a try.

![OutputViewer](https://itlezy.github.io/images/OV%20_%20Examples.png)

Integrated JSON Viewer

![JSON](https://itlezy.github.io/images/JSONViewer.png)

### Console
An alternative approach to a Windows Command Prompt. Commands are executed in the background, pressing CTRL-ENTER, the output is visualized as a log file. Inspired by mIRC chat system and SQL Developer.

![Terminal](https://itlezy.github.io/images/Terminal.png)

