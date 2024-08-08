Public Interface IDataSiteRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    Event getResponseSiteInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseBordereauInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseProductionInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseWorkersOnSiteInitialData(sender As Object, args As DataRequestsDataResult)

    Event getResponseloadBordereauTableData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoadRegieTableData(sender As Object, args As DataRequestsDataResult)
    Event getResponseProductionTableData(sender As Object, args As DataRequestsDataResult)
    Event getResponseDeliveryTableData(sender As Object, args As DataRequestsDataResult)

    Event getResponseSavePhotoData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveProductionData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveClosedDaysData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveDeliveryData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveRegieData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveMaterialsReceptionData(sender As Object, args As DataRequestsDataResult)

    Event getResponseLoadJournalData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoadJournalWorkersData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoadJournalWorkersCategoriesData(sender As Object, args As DataRequestsDataResult)
    Event getResponseloadJournalReportData(sender As Object, args As DataRequestsDataResult)
    Event getResponseloadJournalHistoryOfDayData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoadMaterialsReceptionData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoadSiteClosedDaysData(sender As Object, args As DataRequestsDataResult)

    Function loadSiteInitialData() As Boolean

    Function loadBordereauTableData() As Boolean
    Function loadRegieTableData() As Boolean
    Function loadProductionTableData() As Boolean
    Function loadDeliveryTableData() As Boolean

    Function loadJournalData() As Boolean
    Function loadJournalReportData() As Boolean
    Function loadJournalHistoryOfDayData() As Boolean

    Function savePhotoData() As Boolean
    Function saveClosedDaysData() As Boolean
    Function saveProductionData() As Boolean
    Function saveDeliveryData() As Boolean
    Function saveRegieData() As Boolean
    Function saveReceptionMaterialsData() As Boolean

End Interface


