Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports Microsoft.Win32.TaskScheduler

Public Class Scheduler
    Public Shared TaskName As String = "Construction Site Logistics"

    Public Shared Sub SetTask(ByVal filePath As String, ByVal startDate As DateTime, ByVal enabled As Boolean)
        Dim ts = New TaskService()
        Dim td = ts.NewTask()
        td.RegistrationInfo.Author = "Construction Site Logistics"
        td.RegistrationInfo.Description = "Construction Site Logistics"
        td.Triggers.Add(New TimeTrigger With {
            .StartBoundary = startDate,
            .Enabled = enabled
        })
        Dim action = New ExecAction(Assembly.GetExecutingAssembly().Location, Nothing, Nothing)

        If filePath <> String.Empty AndAlso File.Exists(filePath) Then
            action = New ExecAction(filePath)
        End If

        action.Arguments = "/Scheduler"
        td.Actions.Add(action)
        ts.RootFolder.RegisterTaskDefinition(TaskName, td)
    End Sub

    Public Shared Sub DeleteTask()
        Dim ts = New TaskService()
        Dim task = ts.RootFolder.GetTasks().Where(Function(a) a.Name.ToLower() = TaskName.ToLower()).FirstOrDefault()

        If task IsNot Nothing Then
            ts.RootFolder.DeleteTask(TaskName)
        End If
    End Sub

    Public Shared Function GetTask() As Task
        Dim ts = New TaskService()
        Dim task = ts.RootFolder.GetTasks().Where(Function(a) a.Name.ToLower() = TaskName.ToLower()).FirstOrDefault()
        Return task
    End Function

    Public Shared Function GetNextScheduleTaskDate() As String
        Try
            Dim task = Scheduler.GetTask()

            If task IsNot Nothing Then
                Dim trigger = task.Definition.Triggers.ToArray.FirstOrDefault

                If trigger IsNot Nothing Then
                    If trigger.TriggerType = TaskTriggerType.Weekly Then
                        If trigger.Enabled Then
                            Dim weeklyTrigger = CType(trigger, WeeklyTrigger)
                            Return task.NextRunTime.ToString("yyyy MMM. dd dddd 'at ' HH:mm")
                        End If
                    End If
                End If
            End If

        Catch __unusedException1__ As Exception
        End Try

        Return "no scheduled date!"
    End Function
End Class

