import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HeroService } from '../services/hero.service';

@Component({
  selector: 'app-select-hero',
  templateUrl: './select-hero.component.html',
  styleUrl: './select-hero.component.scss',
})
export class SelectHeroComponent {
  @Input() control: FormControl<string | null> = new FormControl('');
  heroes: string[] = [];

  constructor(private heroService: HeroService) {
    this.heroService.getHeroes$().subscribe((heroes) => {
      this.heroes = heroes.map((hero) => hero.name);
    });
  }
}
