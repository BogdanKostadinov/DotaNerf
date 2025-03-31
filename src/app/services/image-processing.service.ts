import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ImageAnalysisResult } from '../models/image.model';

@Injectable({
  providedIn: 'root',
})
export class ImageProcessingService {
  // replace this apiUrl with the one you get from the backend
  private apiUrl = 'http://localhost:3000/api/image-processing';

  constructor(private http: HttpClient) {}

  processImage(imageFile: File): Observable<ImageAnalysisResult> {
    const formData = new FormData();
    formData.append('file', imageFile);

    return this.http.post<ImageAnalysisResult>(this.apiUrl, formData);
  }
}
