import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Invoice } from '../_models/AE-invoice.model';
import { GetDocumentsResponse, SubmittedDocument } from '../_models/documents.response.model';

@Injectable()
export class DocumentService {
    constructor(private http: HttpClient) { }

    getDocuments(pageNumber: number, pageSize: number) {
        return this.http.get<GetDocumentsResponse>(`/api/Documents/get?pageNumber=${pageNumber}&pageSize=${pageSize}`);
    }

    submitDocument(invoiceIds: string[]) {
        return this.http.post<SubmittedDocument>('/api/invoices/save', invoiceIds);
    }
}
