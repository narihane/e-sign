import { Component, OnInit, EventEmitter } from '@angular/core';
import { UploadFile, UploadInput, UploadOutput } from 'ng-uikit-pro-standard';
import { humanizeBytes } from 'ng-uikit-pro-standard';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UploadFilesService } from '../shared/_services/upload-file.service';
@Component({
  selector: 'app-code-mapping',
  templateUrl: './code-mapping.component.html',
  styleUrls: ['./code-mapping.component.css']
})
export class CodeMappingComponent {
  // formData!: FormData;
  // files: UploadFile[];
  // uploadInput: EventEmitter<UploadInput>;
  // humanizeBytes: Function;
  // dragOver!: boolean;


  selectedFiles?: FileList;
  currentFile?: File;
  progress = 0;
  message = '';

  fileInfos?: Observable<any>;

  constructor(private uploadService: UploadFilesService) { }

  ngOnInit(): void {
    this.fileInfos = this.uploadService.getFiles();
  }

  selectFile(event: any): void {
    this.selectedFiles = event.target.files;
  }

  upload(): void {
    this.progress = 0;

    if (this.selectedFiles) {
      const file: File | null = this.selectedFiles.item(0);

      if (file) {
        this.currentFile = file;

        this.uploadService.upload(this.currentFile).subscribe(
          (event: any) => {
            if (event.type === HttpEventType.UploadProgress) {
              this.progress = Math.round(100 * event.loaded / event.total);
            } else if (event instanceof HttpResponse) {
              this.message = event.body.message;
              this.fileInfos = this.uploadService.getFiles();
            }
          },
          (err: any) => {
            console.log(err);
            this.progress = 0;

            if (err.error && err.error.message) {
              this.message = err.error.message;
            } else {
              this.message = 'Could not upload the file!';
            }

            this.currentFile = undefined;
          });

      }

      this.selectedFiles = undefined;
    }
  }
}

  // showFiles() {
  //   let files = '';
  //   for (let i = 0; i < this.files.length; i++) {
  //     files += this.files[i].name;
  //     if (!(this.files.length - 1 === i)) {
  //       files += ',';
  //     }
  //   }
  //   return files;
  // }

  // startUpload(): void {
  //   const event: UploadInput = {
  //     type: 'uploadAll',
  //     url: '',
  //     method: 'POST',
  //     data: {  },
  //   };
  //   this.files = [];
  //   this.uploadInput.emit(event);
  // }

  // cancelUpload(id: string): void {
  //   this.uploadInput.emit({ type: 'cancel', id: id });
  // }

  // onUploadOutput(output: UploadOutput | any): void {

  //   if (output.type === 'allAddedToQueue') {
  //   } else if (output.type === 'addedToQueue') {
  //     this.files.push(output.file); // add file to array when added
  //   } else if (output.type === 'uploading') {
  //     // update current data in files array for uploading file
  //     const index = this.files.findIndex(file => file.id === output.file.id);
  //     this.files[index] = output.file;
  //   } else if (output.type === 'removed') {
  //     // remove file from array when removed
  //     this.files = this.files.filter((file: UploadFile) => file !== output.file);
  //   } else if (output.type === 'dragOver') {
  //     this.dragOver = true;
  //   } else if (output.type === 'dragOut') {
  //   } else if (output.type === 'drop') {
  //     this.dragOver = false;
  //   }
  //   this.showFiles();
  // }

