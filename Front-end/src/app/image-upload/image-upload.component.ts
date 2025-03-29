import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ImageAnalysisResult } from '../models/image.model';
import { ImageProcessingService } from '../services/image-processing.service';

@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrl: './image-upload.component.scss',
})
export class ImageUploadComponent {
  selectedFile: File | null = null;
  imagePreview: string | ArrayBuffer | null = null;
  isProcessing = false;
  processingResult: ImageAnalysisResult | null = null;

  constructor(
    private imageProcessingService: ImageProcessingService,
    private snackBar: MatSnackBar,
  ) {}

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;

    if (input.files && input.files.length) {
      this.selectedFile = input.files[0];

      // Create preview
      const reader = new FileReader();
      reader.onload = () => {
        this.imagePreview = reader.result;
      };
      reader.readAsDataURL(this.selectedFile);

      // Reset previous results
      this.processingResult = null;
    }
  }

  processImage(): void {
    if (!this.selectedFile) {
      this.snackBar.open('Please select an image first', 'Close', {
        duration: 3000,
      });
      return;
    }

    this.isProcessing = true;

    this.imageProcessingService.processImage(this.selectedFile).subscribe({
      next: (result: any) => {
        this.processingResult = result;
        this.isProcessing = false;
      },
      error: (error: any) => {
        console.error('Error processing image:', error);
        this.snackBar.open('Error processing image', 'Close', {
          duration: 5000,
        });
        this.isProcessing = false;
      },
    });
  }

  resetForm(): void {
    this.selectedFile = null;
    this.imagePreview = null;
    this.processingResult = null;
  }
}
