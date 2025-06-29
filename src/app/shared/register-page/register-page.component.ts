import { Component } from '@angular/core';
import {
  AbstractControl,
  AsyncValidatorFn,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { map, of } from 'rxjs';
import { CreateUserDTO } from '../../models/user.model';
import { UserService } from '../../services/user.service';
import { SnackbarService } from '../snackbar/snackbar.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.scss',
})
export class RegisterPageComponent {
  registerForm: FormGroup;
  hidePassword = true;
  hideConfirm = true;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private snackBarService: SnackbarService,
    private router: Router,
  ) {
    this.registerForm = this.fb.group({
      email: ['', Validators.required, [this.emailExistsValidator()]],
      userName: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });

    this.registerForm.get('confirmPassword')?.valueChanges.subscribe(() => {
      this.checkPasswordMatch();
    });
    this.registerForm.get('password')?.valueChanges.subscribe(() => {
      if (this.registerForm.get('confirmPassword')?.value) {
        this.checkPasswordMatch();
      }
    });
  }

  registerUser() {
    if (this.registerForm.valid) {
      const user: CreateUserDTO = {
        email: this.registerForm.get('email')?.value,
        userName: this.registerForm.get('userName')?.value,
        password: this.registerForm.get('password')?.value,
      };

      this.userService.createUser(user).subscribe({
        next: (response) => {
          this.registerForm.reset();
          this.snackBarService.success(
            `User ${response.userName} registered successfully!`,
          );
          this.router.navigate(['/players']);
        },
        error: (error) => {
          console.error('Error registering user:', error);
        },
      });
    }
  }

  emailExistsValidator(): AsyncValidatorFn {
    return (control: AbstractControl) => {
      if (!control.value) {
        return of(null);
      }
      return this.userService.getUsers().pipe(
        map((users) => {
          const exists = users.some((user) => user.email === control.value);
          return exists ? { emailExists: true } : null;
        }),
      );
    };
  }

  private checkPasswordMatch() {
    const password = this.registerForm.get('password')?.value;
    const confirmPassword = this.registerForm.get('confirmPassword')?.value;

    if (password !== confirmPassword) {
      this.registerForm
        .get('confirmPassword')
        ?.setErrors({ passwordMismatch: true });
    } else {
      // Only clear the passwordMismatch error, not other errors
      const errors = this.registerForm.get('confirmPassword')?.errors;
      if (errors) {
        delete errors['passwordMismatch'];
        const hasOtherErrors = Object.keys(errors).length > 0;
        this.registerForm
          .get('confirmPassword')
          ?.setErrors(hasOtherErrors ? errors : null);
      }
    }
  }

  onSubmit() {
    if (this.registerForm.valid) {
      console.log('Form submitted:', this.registerForm.value);
    }
  }
}
