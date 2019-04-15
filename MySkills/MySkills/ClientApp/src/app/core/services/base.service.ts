import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

export abstract class BaseService<T> {
  readonly rootURL = 'https://localhost:5001/api/Notes/';

  constructor(protected http: HttpClient) {
  }

  public getServiceUrl(endPoint?: string): string {
    if (endPoint) {
      return this.rootURL.concat(endPoint);
    } else {
      return this.rootURL;
    }
  }

  public findById(id: any, endPoint?: string): Observable<T> {
    return this.http.get<T>(this.getServiceUrl(endPoint) + '/' + id);
  }

  public findAll(endPoint?: string, params?): Observable<T[]> {
    return this.http.get<T[]>(this.getServiceUrl(endPoint), { params: params });
  }

  public delete(id, endPoint?: string): Observable<T> {
    return this.http.delete<T>(this.getServiceUrl(endPoint) + '/' + id);
  }

  public insert(data: T, endPoint?: string): Observable<T> {
    return this.http.post<T>(this.getServiceUrl(endPoint), JSON.stringify(data), { headers: this.getHttpHeaders() });
  }

  public update(fieldId: string, data: T, endPoint?: string): Observable<T> {
    const url = this.getServiceUrl(endPoint) + '/' + data[fieldId];
    return this.http.put<T>(url, JSON.stringify(data), { headers: this.getHttpHeaders() });
  }

  private getHttpHeaders(): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return headers;
  }
}