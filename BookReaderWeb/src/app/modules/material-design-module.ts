import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material';
import {MatToolbarModule} from '@angular/material/toolbar'; 

@NgModule({
    exports: [
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatSnackBarModule,
        MatToolbarModule
    ]
})
export class MaterialDesignModule {}
