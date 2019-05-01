<?php

// генерація посторінкової пагінації
class Pagination
{
    // FIELDS
    private $max; // кл посилань на сторінці
    private $index;// ключ GET в якому записується номер сторінки
    private $current_page;// данна сторінка
    private $total;// загальні кількість записів
    private $limit;// записів на сторінку

    // CONSTRUCTORS
    public function __construct($total, $currentPage, $limit, $index)
    {
        $this->max = PAGINATION_PAGE_SHOWN;
        $this->total = $total;
        $this->limit = $limit;
        $this->index = $index;
        $this->amount = $this->amount();        
        $this->setCurrentPage($currentPage);
    }
    
    // METHODS
    // @return HTML-код із посиланнями навігації
    public function get()
    {
        $links = null;
        $limits = $this->limits();
        
        $html = '<ul class="pagination justify-content-center">'.PHP_EOL;
        // генеруємо посилання
        for ($page = $limits[0]; $page <= $limits[1]; ++$page) 
        {
            # Если текущая это текущая страница, ссылки нет и добавляется класс active
            if ($page == $this->current_page) 
            {
                $links .= PHP_EOL."\t\t\t".'<li class="page-item active" aria-current="page">
                            <a class="page-link" href="#">' . $page . '</a>
                        </li>';
            } 
            else 
            {
                $links .= $this->generateHtml($page);
            }
        }

        // якщо посилання створились, додаємо кнопки Previos, Next
        if (!is_null($links)) 
        {
            // previous
            $is_button_enabled = $this->current_page > 1;
            $button_page = $is_button_enabled ? $this->current_page - 1 : $this->current_page;
            $links = $this->generateHtml($button_page, 'Previous', !$is_button_enabled) . $links;

            // next
            $is_button_enabled = $this->current_page < $this->amount;
            $button_page = $is_button_enabled ? $this->current_page + 1 : $this->current_page;
            $links .= $this->generateHtml($button_page, 'Next', !$is_button_enabled);
        }

        $html .= $links . "\t\t</ul>";

        
        return $html;
    }

    private function generateHtml($page, $text = null, $isDisabled = false)
    {
        // text = цифра сторінки
        if (!$text) $text = $page;

        $currentURI = rtrim($_SERVER['REQUEST_URI'], '/') . '/';
        $currentURI = preg_replace('~/page-[0-9]+~', '', $currentURI);
        
        return 
            PHP_EOL."\t\t\t".'<li class="page-item '. ($isDisabled ? 'disabled' : '') .'">
                <a class="page-link" href="' . $currentURI . $this->index . $page . '"> '. $text .'</a>
            </li>'.PHP_EOL;
    }

    // Від якого посилання рахувати
    // @return масив із початком і кінцем підрахунку
    private function limits()
    {
        // вираховуємо посилання зліва, щоб активне посиланння було посередині
        $left = $this->current_page - round($this->max / 2);
        
        // початок відрахунку
        $start = $left > 0 ? $left : 1;

        if ($start + $this->max <= $this->amount) 
        {
            $end = $start > 1 ? $start + $this->max : $this->max;
        } 
        else 
        {
            $end = $this->amount;

            $start = $this->amount - $this->max > 0 ? $this->amount - $this->max : 1;
        }

        return array($start, $end);
    }

    private function setCurrentPage($currentPage)
    {
        $this->current_page = $currentPage;
        
        if ($this->current_page > 0) 
        {
            if ($this->current_page > $this->amount)
            {
                $this->current_page = $this->amount;                
            }
        } 
        else
        {
            $this->current_page = 1;            
        }
    }
    // @return загальна кількість сторінок
    private function amount()
    {
        return ceil($this->total / $this->limit);
    }

}