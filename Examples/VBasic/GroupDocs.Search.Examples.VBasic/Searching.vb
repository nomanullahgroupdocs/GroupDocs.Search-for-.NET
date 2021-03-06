﻿Imports Aspose.Email.Outlook.Pst

Public Class Searching
    ''' <summary>
    ''' Creates index, adds documents to index and search string in index
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub SimpleSearch(searchString As String)
        'ExStart:SimpleSearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Search in index
        Dim searchResults As SearchResults = index.Search(searchString)

        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:SimpleSearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do boolean search
    ''' </summary>
    ''' <param name="firstTerm">first term to search</param>
    ''' <param name="secondTerm">second term to search</param>
    Public Shared Sub BooleanSearch(firstTerm As String, secondTerm As String)
        'ExStart:BooleanSearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Search in index
        Dim searchResults As SearchResults = index.Search(Convert.ToString(firstTerm & Convert.ToString("OR")) & secondTerm)

        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", firstTerm, documentResultInfo.HitCount, documentResultInfo.FileName)
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", secondTerm, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:BooleanSearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do regex search
    ''' </summary>
    ''' <param name="relevantKey">single keyword</param>
    ''' <param name="regexString">regex</param>
    Public Shared Sub RegexSearch(relevantKey As String, regexString As String)
        'ExStart:Regexsearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Search for documents where at least one word contain given regex
        Dim searchResults1 As SearchResults = index.Search(relevantKey)

        'Search for documents where present term1 or any email adress or term2
        Dim searchResults2 As SearchResults = index.Search(regexString)

        ' List of found files 
        Console.WriteLine("Follwoing document(s) contain provided relevant tag: " & vbLf)
        For Each documentResultInfo As DocumentResultInfo In searchResults1
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", relevantKey, documentResultInfo.HitCount, documentResultInfo.FileName)
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", regexString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next

        ' List of found files
        Console.WriteLine("Follwoing document(s) contain provided RegEx: " & vbLf)
        For Each documentResultInfo As DocumentResultInfo In searchResults2
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", relevantKey, documentResultInfo.HitCount, documentResultInfo.FileName)
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", regexString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:Regexsearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do fuzzy search
    ''' </summary>
    ''' <param name="searchString">Misspelled string</param>
    Public Shared Sub FuzzySearch(searchString As String)
        'ExStart:Fuzzysearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        Dim parameters As New SearchParameters()
        parameters.UseFuzzySearch = True

        Dim searchResults As SearchResults = index.Search(searchString, parameters)

        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.WriteLine(documentResultInfo.FileName + vbLf)
        Next
        'ExEnd:Fuzzysearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do faceted search
    ''' </summary>
    ''' <param name="searchString">search string</param>
    Public Shared Sub FacetedSearch(searchString As String)
        'ExStart:Facetedsearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Searching for any document in index that contain word "return" in file content
        Dim searchResults As SearchResults = index.Search(Convert.ToString("Content:") & searchString)


        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:Facetedsearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and searches file name that containes similar/inputted string 
    ''' </summary>
    ''' <param name="searchString">search string</param>
    Public Shared Sub SearchFileName(searchString As String)
        'ExStart:SearchFileName
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Searching for any document in index that contain search string in file name
        Dim searchResults As SearchResults = index.Search(Convert.ToString("FileName:") & searchString)


        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:SearchFileName
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do faceted search combine with boolean search
    ''' </summary>
    ''' <param name="firstTerm">first term</param>
    ''' <param name="secondTerm">second term</param>
    Public Shared Sub FacetedSearchWithBooleanSearch(firstTerm As String, secondTerm As String)
        'ExStart:FacetedSearchWithBooleanSearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)
        'Faceted search combine with boolean search
        Dim searchResults As SearchResults = index.Search(Convert.ToString((Convert.ToString("Content:") & firstTerm) + "OR Content:") & secondTerm)

        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", firstTerm, documentResultInfo.HitCount, documentResultInfo.FileName)
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", secondTerm, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:FacetedSearchWithBooleanSearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do search on the basis of synonyms by turning synonym search true
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub SynonymSearch(searchString As String)
        'ExStart:SynonymSearch
        ' Create or load index
        Dim index As New Index(Utilities.indexPath)

        ' load synonyms
        index.LoadSynonyms(Utilities.synonymFilePath)

        index.AddToIndex(Utilities.documentsPath)

        ' Turning on synonym search feature
        Dim parameters As New SearchParameters()
        parameters.UseSynonymSearch = True

        ' searching for documents with words one of words "remote", "virtual" or "online"
        Dim searchResults As SearchResults = index.Search(searchString, parameters)

        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:SynonymSearch
    End Sub

    ''' <summary>
    ''' Shows how to implement own custom extractor for outlook document for the extension .ost and .pst files
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub OwnExtractorOst(searchString As String)
        'ExStart:OwnExtractorOst
        ' Create or load index
        Dim index As New Index(Utilities.indexPath)

        index.CustomExtractors.Add(New CustomOstPstExtractor())
        ' Adding new custom extractor for container document
        index.AddToIndex(Utilities.documentsPath)
        ' Documents with "ost" and "pst" extension will be indexed using MyCustomContainerExtractor
        Dim searchResults As SearchResults = index.Search(searchString)
        'ExEnd:OwnExtractorOst
    End Sub

    ''' <summary>
    ''' Shows how to implement own custom extractor for outlook document for the extension .ost and .pst files
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub DetailedResults(searchString As String)
        'ExStart:DetailedResultsPropertyInDocuments
        ' Create or load index
        Dim index As New Index(Utilities.indexPath)
        index.AddToIndex(Utilities.documentsPath)

        Dim results As SearchResults = index.Search(searchString)

        For Each resultInfo As DocumentResultInfo In results
            If resultInfo.DocumentType = DocumentType.OutlookEmailMessage Then
                ' for email message result info user should cast resultInfo as OutlookEmailMessageResultInfo for acessing EntryIdString property
                Dim emailResultInfo As OutlookEmailMessageResultInfo = TryCast(resultInfo, OutlookEmailMessageResultInfo)

                Console.WriteLine("Query ""{0}"" has {1} hit count in message {2} in file {3}", searchString, emailResultInfo.HitCount, emailResultInfo.EntryIdString, emailResultInfo.FileName)
            Else
                Console.WriteLine("Query ""{0}"" has {1} hit count in file {2}", searchString, resultInfo.HitCount, resultInfo.FileName)
            End If

            For Each detailedResult As DetailedResultInfo In resultInfo.DetailedResults
                Console.WriteLine("{0}In field ""{1}"" there was found {2} hit count", vbTab, detailedResult.FieldName, detailedResult.HitCount)
            Next
        Next
        'ExEnd:DetailedResultsPropertyInDocuments
    End Sub

    Public Sub OpenFoundMessageUsingAsposeEmail(searchString As String)
        Dim myPstFile As String = Utilities.pathToPstFile


        ' Indexing MS Outlook storage with email messages
        Dim index As New Index(Utilities.indexPath)
        AddHandler index.OperationFinished, Utilities.index_OperationFinished
        index.AddToIndex(myPstFile)

        ' Searching in index
        Dim results As SearchResults = index.Search(searchString)

        ' User gets all messages that qualify to search query using Aspose.Email API
        Dim messages As New MessageInfoCollection()
        For Each searchResult As DocumentResultInfo In results
            If searchResult.DocumentType = DocumentType.OutlookEmailMessage Then
                Dim emailResultInfo As OutlookEmailMessageResultInfo = TryCast(searchResult, OutlookEmailMessageResultInfo)
                Dim message As MessageInfo = GetEmailMessagesById(Utilities.pathToPstFile, emailResultInfo.EntryIdString)
                If message IsNot Nothing Then
                    messages.Add(message)
                End If
            End If
        Next
    End Sub

    Private Function GetEmailMessagesById(fileName As String, fieldId As String) As MessageInfo
        Dim pst As PersonalStorage = PersonalStorage.FromFile(fileName, False)
        Return GetEmailMessagesById(pst.RootFolder, fieldId)
    End Function

    Private Function GetEmailMessagesById(folderInfo As FolderInfo, fieldId As String) As MessageInfo
        Dim result As MessageInfo = Nothing
        Dim messageInfoCollection As MessageInfoCollection = folderInfo.GetContents()
        For Each messageInfo As MessageInfo In messageInfoCollection
            If messageInfo.EntryIdString = fieldId Then
                result = messageInfo
                Exit For
            End If
        Next

        If result Is Nothing AndAlso folderInfo.HasSubFolders Then
            For Each subfolderInfo As FolderInfo In folderInfo.GetSubFolders()
                result = GetEmailMessagesById(subfolderInfo, fieldId)
                If result IsNot Nothing Then
                    Exit For
                End If
            Next
        End If
        Return result
    End Function

End Class
