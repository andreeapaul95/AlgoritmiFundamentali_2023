import { Component } from '@angular/core';
import { User } from '../models/user';
import { UsersService } from '../services/users.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent {
  user: User = {} as User;
  isLoading: boolean = true;

  constructor(private usersService: UsersService, private route: ActivatedRoute) {
    let id: number = +route.snapshot.params['id'];

    this.usersService.getOneUser(id).subscribe(async (res) => {
      await this.delay(1000);
      this.isLoading = false;
      this.user = res;
    });
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms) );
  }
}
